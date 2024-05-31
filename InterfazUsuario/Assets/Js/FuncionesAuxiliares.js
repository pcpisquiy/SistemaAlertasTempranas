const CreateElement = (type_element, text_element, value_element=null,Clases=[],Atributos=[]) =>{
    let Element = document.createElement(type_element);
    if (text_element != null) {
        Element.textContent = text_element;
    }
    if (value_element != null) {
        Element.value = value_element;
    }
    if (Clases.length > 0) {
        Clases.forEach((Clase) => {
            Element.classList.add(Clase);
        })
    }
    if (Atributos.length > 0 && (Atributos.length%2)==0) {
        for (var i = 2; i <= Atributos.length; i+=2) {
            Element.setAttribute(Atributos[i - 2], Atributos[i - 1]);
        }
    }
    return Element;
}