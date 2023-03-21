var min = 1;
var max = 20;
var aleatorio= Math.floor(Math.random() * max - min + 1) + min;
var intentos=1;
let puntaje=20;
let puntuacion=0;

function probarJuego(){
    let numero= document.getElementById("nroIngresado").value;
    while (intentos < 5){
        
        console.log("numero: "+numero);
        console.log("adivinar :"+aleatorio)
    
        if(numero >= min && numero <= max){
            if(numero < aleatorio){
                evaluarNumero('BAJO');
            }else if(numero > aleatorio){
                evaluarNumero('ALTO');
            }else{
                cambiarFondo('chartreuse');  
                resultado('FELICIDADES ACERTASTE!!');                                          
                break;
            }
        }else{
            alert("El numero ingresado esta fuera del rango");
        }
        
        console.log("intentos: "+intentos);  
        intentos ++;

        if (intentos === 5){
            resultado('PERDISTE! Agotaste el numero de intentos');
            cambiarFondo("tomato");
        }
        numero.focus(); 
    }

}

function cambiarFondo(x){
    var body= document.getElementById("body");
    document.body.style.backgroundColor= x;
}

function evaluarNumero(t){
    document.getElementById("Acertar").innerHTML= ('El numero ingresado es ' +t);
    puntaje= puntaje - 5;
    document.getElementById("puntaje").innerHTML= puntaje;
    document.getElementById("puntuacion").innerHTML= puntuacion;
}

function resultado(mje){
    document.getElementById("Acertar").innerHTML= mje;
    document.getElementById("resultado").innerHTML=  'El numero es '+aleatorio;
    puntuacion= puntaje;
    document.getElementById("puntaje").innerHTML= puntaje;
    document.getElementById("puntuacion").innerHTML= puntuacion; 
}

function refrescarPag(){
    location.reload();
}