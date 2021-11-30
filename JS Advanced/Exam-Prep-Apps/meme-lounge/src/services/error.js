export function displayError(message) {
    const errorDiv = document.querySelector('#errorBox');
    const spanElement = errorDiv.querySelector('span');

    spanElement.textContent = message;
    errorDiv.style.display = 'block';

    setTimeout(() => errorDiv.style.display = 'none', 3000);
}