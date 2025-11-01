import pandas as pd
from sklearn.metrics import (
    accuracy_score,
    precision_recall_fscore_support,
    confusion_matrix as sk_confusion_matrix,
    roc_auc_score
)


def all_metrics(model, x_train, x_test, y_test, y_pred):
    classification_metrics(y_test, y_pred)
    confusion_matrix(y_test, y_pred)
    roc_auc(model, x_test, y_test)
    feature_importances(model, x_train)


def classification_metrics(y_test, y_pred):
    acc = accuracy_score(y_test, y_pred)
    prec, rec, f1, _ = precision_recall_fscore_support(y_test, y_pred, average="binary", pos_label=1, zero_division=0)
    tn, fp, fn, tp = sk_confusion_matrix(y_test, y_pred).ravel()
    specificity = tn / (tn + fp) if (tn + fp) > 0 else 0.0
    print(f"Accuracy : {acc:.4f}")
    print(f"Precision: {prec:.4f}")
    print(f"Recall   : {rec:.4f}")
    print(f"F1-score : {f1:.4f}")
    print(f"Specificity : {specificity:.4f}")


def confusion_matrix(y_test, y_pred):
    cm = sk_confusion_matrix(y_test, y_pred)
    print("\nConfusion matrix [[TN, FP], [FN, TP]]:")
    print(cm)


def roc_auc(model, x_test, y_test):
    if hasattr(model, "predict_proba"):
        y_proba = model.predict_proba(x_test)[:, 1]  # uzima verovatnoću za pripadanje klasi 1 za svaki red u test set-u
        auc = roc_auc_score(y_test, y_proba)
        print(f"ROC-AUC  : {auc:.4f}")


def feature_importances(model, x_train, n_feature_importances=15):
    if hasattr(model, "feature_importances_"):
        feat_imp = pd.Series(model.feature_importances_, index=x_train.columns)\
                     .sort_values(ascending=False).head(n_feature_importances)
        print(f"\nTop {n_feature_importances} feature importances:")
        print(feat_imp.to_string())
