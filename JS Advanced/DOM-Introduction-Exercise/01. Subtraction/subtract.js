function subtract() {
    let result = document.getElementById('result');
    let firstNumber = Number(document.getElementById('firstNumber').value);
    let secondNumber = Number(document.getElementById('secondNumber').value);
    result.innerHTML = (firstNumber - secondNumber).toString();
}