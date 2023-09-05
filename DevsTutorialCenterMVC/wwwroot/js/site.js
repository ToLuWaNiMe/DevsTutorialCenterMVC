// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Function to toggle the dropdown
function toggleDropdown() {
    var dropdown = document.getElementById('Dropdown');
    if (dropdown.style.display === "block") {
        dropdown.style.display = "none";
    } else {
        dropdown.style.display = "block";
    }
}

// Close the dropdown if the user clicks outside of it
//window.onclick = function (event) {
//    if (!event.target.matches('.dropdown-content')) {
//        var dropdown = document.getElementById("dropdown");
//        if (dropdown.style.display === "block") {
//            dropdown.style.display = "none";
//        }
//    }
//}
