function solve() {
  let btns = document.querySelectorAll('#exercise button');
  let textAreas = document.querySelectorAll('#exercise textarea');

  let generateBtn = btns[0];
  let furnitureInfoInput = textAreas[0];

  generateBtn.addEventListener('click', addFurniture);

  function addFurniture() {

    let tbody = document.querySelector('.table tbody')

    document.querySelectorAll('.table tbody tr td')[4].children[0].disabled = false;

    let inputData = JSON.parse(furnitureInfoInput.value);

    inputData.forEach((f) => {
      let trow = document.createElement('tr');

      let tdImg = createNewElement('td', 'img', f.img);
      let tdName = createNewElement('td', 'p', f.name);
      let tdPrice = createNewElement('td', 'p', f.price);
      let tdDecFactor = createNewElement('td', 'p', f.decFactor);
      let tdCheckBox = createNewElement('td', 'input');

      trow.appendChild(tdImg);
      trow.appendChild(tdName);
      trow.appendChild(tdPrice);
      trow.appendChild(tdDecFactor);
      trow.appendChild(tdCheckBox);

      tbody.appendChild(trow);
    });
  };

  function createNewElement(tagName, childTagName, content) {

    let parent = document.createElement(tagName)
    let child = document.createElement(childTagName);

    if(childTagName === 'p') {
      child.textContent = content;
    } else if(childTagName === 'img') {
      child.src = content;
    } else if(childTagName === 'input') {
      child.type = "checkbox";
      child.disabled = false;
    }
    
    parent.appendChild(child);

    return parent;
  };

  let buyBtn = btns[1];
  let orderInfo = textAreas[1];

  buyBtn.addEventListener('click', collectItems);

  function collectItems() {
      let boughtFurnitures = Array.from(document.querySelectorAll('.table tbody tr'))
                                                .filter(e => e.children[4].children[0].checked == true);
      let furnitures = 'Bought furniture: ';

      let total = 0;
      let decFactor = 0;

      boughtFurnitures.forEach((f) => {
        furnitures += f.children[1].children[0].textContent + ', ';
        total += Number(f.children[2].children[0].textContent);
        decFactor += Number(f.children[3].children[0].textContent);
      });

      let totalPrice = `Total price: ${total.toFixed(2)}`;
      let avgDecoFactor = `Average decoration factor: ${decFactor / boughtFurnitures.length}`;

      orderInfo.value = furnitures.substring(0, furnitures.length - 2) + '\n' + totalPrice + '\n' + avgDecoFactor;
  };
};