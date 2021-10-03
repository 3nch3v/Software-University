function search() {
   const towns = Array.from(document.querySelectorAll('#towns li'));
   const searchText = document.querySelector('#searchText').value;
   const result = document.querySelector('#result');
   let matches = 0;

   towns.forEach((t) => {
      if(t.textContent.includes(searchText)) {
         t.style.fontWeight = 'bold';
         t.style.textDecoration = 'underline';
         matches++;
      } else {
         t.style.fontWeight = 'none';
         t.style.textDecoration = 'none';
      }
   });

   result.innerHTML = `${matches} matches found`
}
