import pandas as pd
from scipy.stats import chi2_contingency
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns


def print_columns(df):
    print("Column names:", list(df.columns))
    print(f"Total columns for the dataset: {len(list(df.columns))}\n")


def print_rows(df, n_rows=0):
    print(f"Total rows for the dataset: {len(df)}")

    if n_rows == 0:
        return

    pd.set_option("display.max_columns", None)
    pd.set_option("display.width", None)

    print(df.head(n_rows))

    pd.reset_option("display.max_columns")
    pd.reset_option("display.width")


def print_missing_values(df):
    missing_rows_per_column = df.isnull().sum()
    total_missing_values = df.isnull().sum().sum()
    rows_with_missing_values = df.isnull().any(axis=1).sum()

    print(f"Missing rows per columns: {missing_rows_per_column}")
    print(f"Total missing values: {total_missing_values}")
    print(f"Rows with missing values: {rows_with_missing_values}")


def print_value_frequencies(df, normalize=True, top_n=5):
    for col in df.columns:
        print_column_value_frequencies(df, col, normalize, top_n)


def print_column_value_frequencies(df, col, normalize=True, top_n=5):
    print("----------------------------")
    print(f"Column: {col}")
    print("----------------------------")
    value_counts = df[col].value_counts(normalize=normalize)
    print(value_counts.head(top_n))
    print(f"... total unique values: {df[col].nunique()}")


def print_cramers_heat_map_matrix(train, target="target", title="Cramer's heat map", figsize=(10, 8)):

    def cramers_v(x, y):
        confusion_matrix = pd.crosstab(x, y)
        chi2 = chi2_contingency(confusion_matrix)[0]
        n = confusion_matrix.sum().sum()
        phi2 = chi2 / n
        r, k = confusion_matrix.shape
        phi2corr = max(0, phi2 - (k - 1) * (r - 1) / (n - 1))
        rcorr = r - (r - 1) ** 2 / (n - 1)
        kcorr = k - (k - 1) ** 2 / (n - 1)
        return np.sqrt(phi2corr / min((kcorr - 1), (rcorr - 1)))

    cat_cols_all = [c for c in train.columns if c != target]
    cramers_matrix = pd.DataFrame(index=cat_cols_all, columns=cat_cols_all)

    for col1 in cat_cols_all:
        for col2 in cat_cols_all:
            if col1 == col2:
                cramers_matrix.loc[col1, col2] = 1.0
            else:
                cramers_matrix.loc[col1, col2] = cramers_v(train[col1], train[col2])

    cramers_matrix = cramers_matrix.astype(float)
    plt.figure(figsize=figsize)
    sns.heatmap(cramers_matrix, annot=False, cmap="coolwarm", center=0)
    plt.title(title)
    plt.tight_layout()
    plt.show()
