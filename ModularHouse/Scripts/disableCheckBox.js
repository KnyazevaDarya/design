function checkAddress(checkbox) {
    if (checkbox.checked == true) { //если включаем чекбокс
        var checkboxes = document.getElementsByClassName('inp-cbx');
        for (var i = 0; i < checkboxes.length; i++) { //проходим по всем чекбоксам
            checkboxes[i].checked = false; //выключаем их
        }
        checkbox.checked = true; //и включаем текущий (потому что до этого выключили все)
    }
}