function toggle() {
  let button = document.getElementsByClassName("button")[0];
  let extraText = document.getElementById("extra");

  extraText.style.display = extraText.style.display == "none" ? "block" : "none"
  button.textContent = button.textContent == "More" ? "Less" : "More"                           
}