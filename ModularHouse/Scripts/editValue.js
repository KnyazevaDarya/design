function getdetails(obj) {
    var hidden_inputs = document.getElementsByClassName('hidden_input');
    for (var i = 0; i < hidden_inputs.length; i++) {
        hidden_inputs[i].value = obj.id;
    }
}