function solve() {
  let text = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  let result = document.getElementById('result');
  
  if(namingConvention == 'Camel Case') {
    let output = text.toLowerCase().split(' ');

    for(let i = 1; i < output.length; i++) {
      output[i] = output[i].charAt(0).toUpperCase() + output[i].slice(1);
    }

    result.textContent = output.join('');
  } else if(namingConvention == 'Pascal Case') {
    let output = text.toLowerCase().split(' ');

    for(let i = 0; i < output.length; i++) {
      output[i] = output[i].charAt(0).toUpperCase() + output[i].slice(1);
    }

    result.textContent = output.join('');
  } else {
    result.textContent = 'Error!';
  }
}