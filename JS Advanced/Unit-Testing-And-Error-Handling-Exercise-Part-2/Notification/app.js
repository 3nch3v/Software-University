function notify(message) {
  let notification = document.querySelector('#notification');

  notification.textContent = message;
  notification.style.display = 'block';

  notification.addEventListener('click', hideEl)

  function hideEl() {
    notification.style.display = 'none';
  };
};