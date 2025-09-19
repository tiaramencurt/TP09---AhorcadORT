document.addEventListener("DOMContentLoaded", function() {
    let palabra = document.getElementById("palabraReal").value.toUpperCase();
    let letrasAdivinadas = [];
    let letrasArriesgadas = [];
    let intentos = parseInt(document.getElementById("intentos").value) || 0;

    function mostrarPalabra() {
        let html = "";
        for (let letra of palabra) {
            if (letrasAdivinadas.includes(letra)) {
                html += `<span class="letra">${letra}</span>`;
            } else {
                html += `<span class="letra oculto">_</span>`;
            }
        }
        document.getElementById("palabra").innerHTML = html;
    }

    function actualizarLetrasArriesgadas() {
        document.getElementById("letrasArriesgadas").textContent = letrasArriesgadas.join(", ");
    }

    function finalizarJuego(mensaje, exito) {
        alert(mensaje);
        document.getElementById("btnFin").classList.remove("d-none");
        if (!exito) {
            document.getElementById("btnVolver").classList.remove("d-none");
        }
        document.getElementById("btnArriesgarLetra").disabled = true;
        document.getElementById("btnArriesgarPalabra").disabled = true;
        document.getElementById("inputLetraPalabra").disabled = true;
    }

    document.getElementById("btnArriesgarLetra").onclick = function() {
        let valor = document.getElementById("inputLetraPalabra").value.trim().toUpperCase();
        if (valor.length !== 1 || !/^[A-ZÑÁÉÍÓÚÜ]$/.test(valor)) {
            alert("Ingresá solo una letra.");
            return;
        }
        if (letrasArriesgadas.includes(valor)) {
            alert("Ya arriesgaste esa letra.");
            return;
        }
        letrasArriesgadas.push(valor);
        if (palabra.includes(valor)) {
            letrasAdivinadas.push(valor);
            // Mostrar letras acertadas
            mostrarPalabra();
            // ¿Completó la palabra?
            if ([...palabra].every(l => l === ' ' || letrasAdivinadas.includes(l))) {
                finalizarJuego(`¡Felicidades! Completaste la palabra en ${intentos + 1} intentos.`, true);
            }
        } else {
            intentos++;
        }
        document.getElementById("intentos").value = intentos;
        actualizarLetrasArriesgadas();
        document.getElementById("inputLetraPalabra").value = "";
    };

    document.getElementById("btnArriesgarPalabra").onclick = function() {
        let valor = document.getElementById("inputLetraPalabra").value.trim().toUpperCase();
        if (valor === palabra) {
            finalizarJuego(`¡Felicidades! Adivinaste la palabra completa en ${intentos + 1} intentos.`, true);
        } else {
            finalizarJuego("Palabra incorrecta. ¡Perdiste! Volvé a intentarlo.", false);
        }
    };

    document.getElementById("btnFin").onclick = function() {
        // Enviá los intentos al endpoint de FinJuego (puede ser con fetch/ajax o usando un form oculto)
        let form = document.createElement('form');
        form.method = "post";
        form.action = "/Home/FinJuego";
        let input = document.createElement('input');
        input.type = "hidden";
        input.name = "intentos";
        input.value = intentos + 1;
        form.appendChild(input);
        document.body.appendChild(form);
        form.submit();
    };

    mostrarPalabra();
    actualizarLetrasArriesgadas();
});