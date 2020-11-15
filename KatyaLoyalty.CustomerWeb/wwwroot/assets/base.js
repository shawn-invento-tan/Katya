/* Custom modals */
var PhoneCountryCodeModal = function (modalSelector, inputSelector) {
    this.modal = $(modalSelector);
    this.input = $(inputSelector);
    this.modalMenu = $(modal).find(".phone-code-selector-menu");
    this.Init = function () {
        $.get("/assets/json/country-codes-with-flags.json", function (data) {
            for (i = 0; i < data.length; i++) {
                var country = data[i];
                var phoneCodeSelectorLink = document.createElement("a");
                var countryNameSpan = document.createElement("span");
                var phoneCodeSpan = document.createElement("span");
                phoneCodeSelectorLink.className = "phone-code-selector-link";
                phoneCodeSelectorLink.setAttribute("data-countrycode", country.countryCode);
                phoneCodeSelectorLink.setAttribute("data-targetinput", outputSelector)
                countryNameSpan.innerHTML = country.name;
                phoneCodeSpan.innerHTML = country.countryCode;
                phoneCodeSelectorLink.appendChild(countryNameSpan);
                phoneCodeSelectorLink.appendChild(phoneCodeSpan);
                $(modalMenu).append(phoneCodeSelectorLink);
            }
            $(".phone-code-selector-link").on("click", function () {
                var phoneCountryCode = $(this).attr("data-countrycode");
                $(modalMenu).val(phoneCountryCode);
                $(modal).modal("toggle");
            })
        })
    }
    return this;
}