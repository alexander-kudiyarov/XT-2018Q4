function Confirmation(pageForRedirect) {
    if (confirm('Are you sure?')) {
        window.location.href = pageForRedirect;
    }
}

function SuccessfulAlert() {
    window.alert("successful");
    window.location.href = "index";
}