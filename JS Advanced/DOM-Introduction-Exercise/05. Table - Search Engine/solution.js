function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchField = document.querySelector('#searchField');
      let searchedWord = searchField.value;
      
      if(!isEmptyOrSpaces(searchedWord)) {
         let rows = Array.from(document.querySelectorAll('.container tbody tr'));

         rows.forEach((r) => {
            let cells = Array.from(r.children);
            let isFound = cells.some((c) => c.textContent.includes(searchedWord));

            if(isFound) {
               r.classList.add('select')
            } else {
               r.classList.remove('select')
            }   
         });
      }

      function isEmptyOrSpaces(str){
         return str === null || str.match(/^ *$/) !== null;
     }

      searchField.value = '';
   }
};