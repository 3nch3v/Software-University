function create(words) {
   let divContent = document.querySelector('#content');

   words.forEach((currString) => {

      let newDiv = document.createElement('div');

      let paragraph = document.createElement('p');

      paragraph.textContent = currString;

      paragraph.style.display = 'none';

      newDiv.appendChild(paragraph);

      newDiv.addEventListener('click', function(e) {

         let targetChild = e.currentTarget.children[0];
         
         targetChild.style.display = '';
      })

      divContent.appendChild(newDiv);
   }) 
}