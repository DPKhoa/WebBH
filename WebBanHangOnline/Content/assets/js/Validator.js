function Validator(options) {

    var selectorRule = {};
    var formElement = document.querySelector(options.form);
    if (formElement) {
        formElement.onsubmit = function (e) {
            e.preventDefault();
            options.rules.forEach((rule) => {
                var inputElement = formElement.querySelector(rule.selector);
                var errMes = inputElement.parentElement.querySelector(".form-message");
                var res;
                // lấy ra các rules của selector
                var rules = selectorRule[rule.selector];
                //lặp qua từng rule và kiểm tra
                for (var i = 0; i < rules.length; ++i) {
                    res = rules[i](inputElement.value);
                    if (res) break;
                }
                if (res) {
                    errMes.innerHTML = res;
                    inputElement.parentElement.classList.add("invalid");
                } else {
                    errMes.innerHTML = "";
                    inputElement.parentElement.classList.remove("invalid");
                }
            });
            inputElement.oninput = function () {
                var errMes = inputElement.parentElement.querySelector(".form-message");
                errMes.innerHTML = "";
                inputElement.parentElement.classList.remove("invalid");
            };
        };
        options.rules.forEach((rule) => {
            if (Array.isArray(selectorRule[rule.selector])) {
                selectorRule[rule.selector].push(rule.test);
            } else {
                selectorRule[rule.selector] = [rule.test];
            }
            // console.log(selectorRule[rule.selector])
            var inputElement = formElement.querySelector(rule.selector);
            if (inputElement) {
                inputElement.onblur = function () {
                    var errMes =
                        inputElement.parentElement.querySelector(".form-message");
                    // var res = rule.test(inputElement.value);
                    var res;
                    // lấy ra các rules của selector
                    var rules = selectorRule[rule.selector];
                    //lặp qua từng rule và kiểm tra
                    for (var i = 0; i < rules.length; ++i) {
                        res = rules[i](inputElement.value);
                        if (res) break;
                    }
                    if (res) {
                        errMes.innerHTML = res;
                        inputElement.parentElement.classList.add("invalid");
                    } else {
                        errMes.innerHTML = "";
                        inputElement.parentElement.classList.remove("invalid");
                    }
                };
                inputElement.oninput = function () {
                    var errMes =
                        inputElement.parentElement.querySelector(".form-message");
                    errMes.innerHTML = "";
                };
            }
        });
    }
}

Validator.isRequired = function (selector) {
    return {
        selector,
        test(value) {
            return value.trim() ? undefined : `Vui lòng nhập đầy đủ`;
        },
    };
};

Validator.isEmail = function (selector) {
    return {
        selector,
        test(value) {
            var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regex.test(value) ? undefined : `Trường này phải là email`;
        },
    };
};

Validator.minLength = function (selector, min) {
    return {
        selector,
        test(value) {
            return value.length >= min
                ? undefined
                : `Vui lòng nhập tối thiểu ${min} ký tự`;
        },
    };
};

Validator.isConfirmed = function (selector, getConfirmValue, message) {
    return {
        selector: selector,
        test: function (value) {
            return value === getConfirmValue()
                ? undefined
                : message || "Giá trị nhập vào không chính xác";
        },
    };
};
