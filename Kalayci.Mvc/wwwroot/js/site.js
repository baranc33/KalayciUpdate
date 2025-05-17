//<div class="collapse navbar-collapse" id="navbarCollapse">
function myFunctionCollapse() {

    const collapsDiv = document.getElementById("navbarCollapses");

    const classes = collapsDiv.classList;

     

    classes.forEach(
        function (value, key, listObj) {
            if (value == "show") {
                collapsDiv.classList.remove("show");
            }
            else {
                collapsDiv.classList.add("show");
            }
        },
    );
}