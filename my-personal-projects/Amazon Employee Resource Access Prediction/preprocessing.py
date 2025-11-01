import pandas as pd
import os
import config
from sklearn.model_selection import train_test_split


def create_sample(sample_size, csv_location, new_sample_name):
    df = pd.read_csv(csv_location)
    df = df.sample(n=sample_size, random_state=config.random_state)

    # index=False jer necemo pandas dataframe-ovu index kolonu
    # snimi samo ako fajl ne postoji
    if not os.path.exists(new_sample_name):
        df.to_csv(new_sample_name, index=False)
        print(f"File {new_sample_name} saved successfully")
    else:
        print(f"File {new_sample_name} already exists.")


def save_file(dataset_to_save, dataset_saving_location, override):
    if os.path.exists(dataset_saving_location) and not override:
        print(f"File {dataset_saving_location} already exists.")
        return

    dataset_to_save.to_csv(dataset_saving_location, index=False)
    print(f"File {dataset_saving_location} saved successfully")


def remove_outlier_rows(df, column_name, most_common_values_to_preserve):
    most_common_values_to_preserve = df[column_name].value_counts().nlargest(most_common_values_to_preserve).index
    df_new = df[df[column_name].isin(most_common_values_to_preserve)]
    print(f"Rows removed: {len(df)-len(df_new)} ({round(((len(df)-len(df_new))/len(df))*100, 4)}% of rows)")
    return df_new


def remove_columns(df, columns_to_remove):
    # normalizovanje kolona, da ne bude bitno da li je uneto malim ili velikim slovima
    cols_to_remove_lower = [c.lower() for c in columns_to_remove]
    cols_to_keep = [col for col in df.columns if col.lower() not in cols_to_remove_lower]
    return df[cols_to_keep]


def stratified_split(df, target="target", test_size=0.2):
    x = df.drop(columns=[target])
    y = df[target]
    x_train, x_test, y_train, y_test = \
        train_test_split(x, y, test_size=test_size, stratify=y, random_state=config.random_state)
    return x_train, x_test, y_train, y_test
