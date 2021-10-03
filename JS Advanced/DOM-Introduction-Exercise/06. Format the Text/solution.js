function solve() {
  let input  = document.querySelector('#input'); 
  let output = document.querySelector('#output');

  let text = input.value
                .split('.')
                .filter((s) => s.length > 0 && s !== "");

  for(let i = 0; i < text.length; i += 3) {
    let paragraph = document.createElement('p');

    for(let j = i; j < i + 3 && j < text.length; j++) {
      paragraph.innerText += `${text[j]}.`;
    };

    if(paragraph.innerText.length > 0) {
      output.appendChild(paragraph);
    };
  };
};