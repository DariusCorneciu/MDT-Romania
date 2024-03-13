// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Detectarea preferinței utilizatorului și aplicarea modului întunecat în funcție de aceasta
const darkModeToggle = document.getElementById('darkModeToggle');

  // Selectează eticheta html
  const htmlTag = document.getElementById('htmlTag');

  // Adaugă un eveniment ascultător pentru schimbarea comutatorului
  darkModeToggle.addEventListener('change', () => {
    // Verifică dacă comutatorul este activat
    if (darkModeToggle.checked) {
      // Adaugă atributul data-bs-theme cu valoarea "dark" la eticheta html
      htmlTag.setAttribute('data-bs-theme', 'dark');
      // Salvează tema dark în local storage
      localStorage.setItem('darkMode', 'enabled');
    } else {
      // Elimină atributul data-bs-theme de pe eticheta html
      htmlTag.removeAttribute('data-bs-theme');
      // Șterge tema dark din local storage
      localStorage.removeItem('darkMode');
    }
  });

  // Verifică dacă tema dark a fost activată anterior și actualizează comutatorul
  if (localStorage.getItem('darkMode') === 'enabled') {
    darkModeToggle.checked = true;
    htmlTag.setAttribute('data-bs-theme', 'dark');
}


