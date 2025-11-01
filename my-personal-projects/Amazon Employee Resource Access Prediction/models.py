import evaluate
import re
import time


def run(models, x_train, x_test, y_train, y_test):
    for model in models:
        print(f"Machine learning algorithm model: {human_readable_model_name(model)}")
        start = time.time()
        model.fit(x_train, y_train)
        y_pred = model.predict(x_test)
        print(f"{human_readable_model_name(model)} finished, ⏱ Duration: {time.time() - start:.2f} seconds")
        evaluate.all_metrics(model, x_train, x_test, y_test, y_pred)


def human_readable_model_name(model):
    return re.sub(r'(?<!^)(?=[A-Z])', ' ', type(model).__name__.replace("Classifier", "")
                                                               .replace("Regressor", ""))\
                                                               .strip()
