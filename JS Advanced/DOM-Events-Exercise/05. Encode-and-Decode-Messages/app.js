function encodeAndDecodeMessages() {
    let divElements = document.querySelectorAll('#main div');

    let sendBtn = divElements[0].children[2];
    sendBtn.addEventListener('click', decodeMessage)

    let decodeBtn = divElements[1].children[2];
    decodeBtn.addEventListener('click', encodeMessage)
   
    let receivedMessage = divElements[1].children[1];
    
    function decodeMessage() {
        let message = divElements[0].children[1];

        let decodedText = '';

        for(let i = 0; i < message.value.length; i++) {
            decodedText += String.fromCharCode(message.value.charCodeAt(i) + 1);
        };

        receivedMessage.value = decodedText;

        message.value = '';
    }

    function encodeMessage() {
        let encodedText = ''

        for(let i = 0; i < receivedMessage.value.length; i++) {
            encodedText += String.fromCharCode(receivedMessage.value.charCodeAt(i) - 1);
        };

        receivedMessage.value = encodedText;
    }
}