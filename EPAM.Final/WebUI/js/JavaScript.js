function Confirmation(pageForRedirect) {
    if (confirm('Are you sure?')) {
        window.location.href = pageForRedirect;
    }
}
