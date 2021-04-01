function Formdata(data) {

	/*если не заполнено поле ИМЯ и длина менее 2-x*/
	if (data.Name != null && data.Name.value.length < 2) {
		alert("Введите Ваше имя");
		return false;
	}

	if (data.Name.value.search(/\d/) != -1) {
		alert("Имя введено неверно! Запрещается использование цифр");
		return false;
	}

	/*если не заполнено поле ФАМИЛИЯ и длина менее 2-x*/
	if (data.Surname != null && data.Surname.value.length < 2) {
		alert("Введите Вашу фамилию");
		return false;
	}

	/*если не заполнено поле e-mail*/
	if (data.EmailAddress != null && data.EmailAddress.value.length == 0) {
		alert("Введите Ваш электронный адрес");
		return false;
	}

	/*Регулярное выражение для проверки e-mail*/
	const re = /^([a-zA-Z\-0-9])+(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

	if (!re.test(String(data.EmailAddress.value).toLowerCase())) {
		alert("Введите электронный адрес корректно");
		return false;
	}

	/*если не заполнено поле вопроса*/
	if (data.QuestionTopic != null && data.QuestionTopic.value.length == 0) {
		alert("Вы не написали Ваш вопрос. Данное поле обязательно для заполнения");
		return false;
	}
}
