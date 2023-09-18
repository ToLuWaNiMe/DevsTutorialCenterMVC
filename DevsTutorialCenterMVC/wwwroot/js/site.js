// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Function to toggle the dropdown
function toggleDropdown() {
    var dropdown = document.getElementById('Dropdown-ify');
    if (dropdown.style.display === "block") {
        dropdown.style.display = "none";
    } else {
        dropdown.style.display = "block";
    }
}


function toggleOption() {
    var options = document.getElementsByClassName('options-view-ify');

    for (let option of options) {
        if (option.style.display === "block") {
            option.style.display = "none";
        } else {
            option.style.display = "block";
        }
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
    
//async function SendInviteForm() {
//    const form = document.getElementById('invite-form');

//    const formData = new FormData(form);

//    const plainFormData = Object.fromEntries(formData.entries());
//    const formDataJsonString = JSON.stringify(plainFormData);

//    const fetchOptions = {
//        method: "POST",
//        headers: {
//            "Content-Type": "application/json",
//            "Accept": "application/json",
//            "RequestVerificationToken": document.getElementsByName("__RequestVerificationToken")[0].value
//        },
//        body: formDataJsonString,
//    };
        
//    // send the form values to your action
//    try {
//        var response = await fetch('https://localhost:7290/Home/SendDecadevInvite', fetchOptions)

//        const data = await response.json();

//        if (data.code == 400) {
            
//            displayErrors(data.error);
//        }

//    } catch (error) {
//        console.error("Error:", error);
//    }
//}

//function displayErrors(errors) {
//    for (let error of errors) {

//        let errorArray = Object.entries(error);

//        let holder = errorArray[0][1];
//        console.log(holder);
//        let errorSpan = $(`span[data-valmsg-for=${holder}]`);
//        console.log(errorSpan);
//        if (errorSpan) {

//            // Display the error message
//            errorSpan.text(errorArray[1][1]); 
//            }
//    }
//}
