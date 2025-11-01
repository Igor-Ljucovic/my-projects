import pandas as pd
from sklearn.compose import ColumnTransformer
from sklearn.preprocessing import OneHotEncoder
import models
import preprocessing as prep
import viewing
import viewing as view
import config
from sklearn.ensemble import RandomForestClassifier
from sklearn.tree import DecisionTreeClassifier
from catboost import CatBoostClassifier
from sklearn.neural_network import MLPClassifier
from lightgbm import LGBMClassifier
import seaborn as sns
import matplotlib.pyplot as plt
import numpy as np
from scipy.stats import chi2_contingency

train = pd.read_csv("train.csv")
train = prep.remove_columns(train, ["ROLE_CODE"])
# train = prep.remove_columns(train, ["MGR_ID"])

# view.print_rows(train)
view.print_column_value_frequencies(train, "ROLE_TITLE")
train = prep.remove_outlier_rows(train, "ROLE_TITLE", 290)
view.print_column_value_frequencies(train, "ROLE_TITLE")

train = prep.remove_outlier_rows(train, "ROLE_FAMILY_DESC", 700)
# train = prep.remove_outlier_rows(train, "MGR_ID", 2600)
# view.print_missing_values(train)
view.print_rows(train)

view.print_columns(train)
# view.print_columns(train_df)
# view.print_rows(train_df, 1)
# view.print_value_counts(train_df)

x_train, x_test, y_train, y_test = prep.stratified_split(train, "ACTION")

# view.print_value_counts(train_df)
view.print_value_frequencies(train)

# print("x_train:\n", x_train)
# print("y_train:\n", y_train)
# print("x_test:\n", x_test)
# print("y_test:\n", y_test)

viewing.print_cramers_heat_map_matrix(train, "ACTION")

rf = RandomForestClassifier(
    n_estimators=401,
    max_depth=23,
    n_jobs=-1,  # da koristi sva jezgra kompjutera
    random_state=config.random_state,
    class_weight="balanced_subsample"
)
dt = DecisionTreeClassifier(
    criterion="gini",
    max_depth=15,
    min_samples_leaf=15,
    class_weight="balanced",
    random_state=config.random_state
)
cb = CatBoostClassifier(
    depth=7,
    learning_rate=0.2,
    iterations=1000,
    l2_leaf_reg=10,
    rsm=0.6,
    auto_class_weights='Balanced',
    random_seed=config.random_state,
    verbose=100,  # za ispis dok se izvrsava
    allow_writing_files=False
)
models.run([rf, dt, cb], x_train, x_test, y_train, y_test)
lgbm = LGBMClassifier(
    n_estimators=401,
    max_depth=-1,
    learning_rate=0.2,
    subsample=0.8,
    colsample_bytree=0.8,
    reg_lambda=1.0,
    random_state=config.random_state,
    class_weight="balanced"
)

models.run([lgbm], x_train, x_test, y_train, y_test)

mlp = MLPClassifier(
    hidden_layer_sizes=(18, 9),
    activation="relu",
    solver="adam",
    learning_rate_init=1e-3,
    alpha=1e-4,
    batch_size=256,
    max_iter=200,
    early_stopping=True,
    n_iter_no_change=15,
    random_state=config.random_state,
    verbose=False
)

models.run([mlp], x_train, x_test, y_train, y_test)

cat_cols = list(x_train.columns)
xtr_cat = x_train[cat_cols].astype(str).fillna("(missing)")
xte_cat = x_test[cat_cols].astype(str).fillna("(missing)")

oh = ColumnTransformer(
    transformers=[(
        "oh",
        OneHotEncoder(handle_unknown="ignore", sparse_output=False),
        cat_cols
    )],
    remainder="drop"
)

X_train_oh = pd.DataFrame(
    oh.fit_transform(xtr_cat),
    columns=oh.named_transformers_["oh"].get_feature_names_out(cat_cols),
    index=x_train.index
)
X_test_oh = pd.DataFrame(
    oh.transform(xte_cat),
    columns=oh.named_transformers_["oh"].get_feature_names_out(cat_cols),
    index=x_test.index
)

mlp = MLPClassifier(
    hidden_layer_sizes=(18, 9),
    activation="relu",
    solver="adam",
    learning_rate_init=1e-3,
    alpha=1e-4,
    batch_size=256,
    max_iter=200,
    early_stopping=True,
    n_iter_no_change=15,
    random_state=config.random_state,
    verbose=False
)

models.run([mlp], X_train_oh, X_test_oh, y_train, y_test)

lgbm = LGBMClassifier(
    n_estimators=401,
    max_depth=-1,
    learning_rate=0.2,
    subsample=0.8,
    colsample_bytree=0.8,
    reg_lambda=1.0,
    random_state=config.random_state,
    class_weight="balanced"
)

models.run([lgbm], X_train_oh, X_test_oh, y_train, y_test)
