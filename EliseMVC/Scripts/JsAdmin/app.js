// upload img admin
function previewImage(input, previewId) {
    var previewElement = document.getElementById(previewId);

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            previewElement.src = e.target.result;
        };
        reader.readAsDataURL(input.files[0]);
    }
}
