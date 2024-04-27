from flask import Flask, request, jsonify

from main import predicted_price

app = Flask(__name__)

@app.route('/predict', methods=['POST'])
def predict():
    # Отримайте дані з запиту
    data = request.json

    # Ваш код для обробки даних та прогнозування цін

    # Поверніть результати у форматі JSON
    return jsonify({'predicted_price': predicted_price})

if __name__ == '__main__':
    app.run(debug=True)
