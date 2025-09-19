let palabraReal = document.getElementById('palabraReal').value.toUpperCase();
let palabra = palabraReal.split('');
let palabraMostrada = [];
let letrasArriesgadas = [];
let intentos = parseInt(document.getElementById('intentos').value);
let juegoTerminado = false;
for (let i = 0; i < palabra.length; i++) {
    palabraMostrada.push('_');
}
function mostrarPalabra() {
    let palabraDiv = document.getElementById('palabra');
    palabraDiv.innerHTML = '';
    for (let i = 0; i < palabraMostrada.length; i++) {
        palabraDiv.innerHTML += '<p class="letra">' + palabraMostrada[i] + '</p>';
    }
}
function mostrarLetrasArriesgadas() {
    document.getElementById('letrasArriesgadas').innerHTML = letrasArriesgadas.join(' - ');
}
function actualizarIntentos() {
    document.getElementById('intentos').value = intentos;
}
function verificarVictoria() {
    if (palabraMostrada.join('') === palabra.join('')) {
        juegoTerminado = true;
        setTimeout(function ()
        {
            alert('¡Felicitaciones! Adivinaste la palabra "' + palabraReal + '" en ' + intentos + ' intentos.');
        }, 100);
        document.getElementById('finJuego').submit();
    }
}
function ArriesgarLetra() {
    let input = document.getElementById('inputLetraPalabra');
    let letra = input.value.trim().toUpperCase();
    if (letra.length !== 1)
    {
        alert('Ingresá una sola letra válida.');
        input.value = '';
    }else if (letrasArriesgadas.includes(letra))
    {
        alert('Ya arriesgaste esa letra.');
        input.value = '';
    }else
        {
            letrasArriesgadas.push(letra);
            let acierto = false;
            for (let i = 0; i < palabra.length; i++)
            {
                if (palabra[i] === letra) {
                    palabraMostrada[i] = letra;
                    acierto = true;
                }
            }
            intentos++;
            mostrarPalabra();
            mostrarLetrasArriesgadas();
            actualizarIntentos();
            verificarVictoria();
            input.value = '';
        }
};
    function ArriesgarPalabra() 
    {
        let input = document.getElementById('inputLetraPalabra');
        let intento = input.value.trim().toUpperCase();
        if (intento == '') 
        {
            alert('Ingresá una palabra.');
        }
        intentos++;
        actualizarIntentos();
        if (intento === palabra.join(''))
        {
            for (let i = 0; i < palabra.length; i++)
            {
                palabraMostrada[i] = palabra[i];
            }
            mostrarPalabra();
            mostrarLetrasArriesgadas();
            verificarVictoria();
        }else 
        {
            mostrarPalabra();
            setTimeout(function () {
                alert('Perdiste, la palabra era "' + palabraReal + '"');
            }, 100);
            document.getElementById('finJuego').submit();
        }
        input.value = '';
};
mostrarPalabra();
mostrarLetrasArriesgadas();
actualizarIntentos();