//input,tables,select
const txtEmergencia = document.getElementById('txtEmergencia');
const DtpFEmergencia = document.getElementById('DtpFEmergencia');
const cmbRegion = document.getElementById('cmbRegion');
const cmbTEmergencia = document.getElementById('cmbTEmergencia');
const btnRegistrarE = document.getElementById('btnRegistrarE');
const frmEmergencia = document.getElementById('frmEmergencia');
//regiones
const ListarRegiones = async()=>{
    try{
        let Url = "https://localhost:44374/Emergencias/ListarRegiones";
        let Response = await fetch(Url,{
            method: "GET",
            headers:{
                "Accept": "application/json",
                "Content-Type": "application/json",
                "charset":"utf-8"
            }
        });
        if(Response.ok && Response.status==200){
            let Regiones = await Response.json();
            cmbRegion.innerHTML="";
            Regiones.forEach(Region => {
                let Option = CreateElement("option",Region.region,Region.id_Region);
                cmbRegion.appendChild(Option);
            });
        }
    } catch(ex){
        alert(ex);
    }
}
//TipoEmergencia
const ListarTipoEmergencia = async()=>{
    try{
        let Url = "https://localhost:44374/Emergencias/ListarTipoEmergencia";
        let Response = await fetch(Url,{
            method: "GET",
            headers:{
                "Accept": "application/json",
                "Content-Type": "application/json",
                "charset":"utf-8"
            }
        });
        if(Response.ok && Response.status==200){
            let TiposEmergencias = await Response.json();
            cmbTEmergencia.innerHTML="";
            TiposEmergencias.forEach(TipoEmergencia => {
                let Option = CreateElement("option",TipoEmergencia.tipo_Emergencia,TipoEmergencia.id_Tipo_Emergencia);
                cmbTEmergencia.appendChild(Option);
            });
        }
    } catch(ex){
        alert(ex);
    }
}

const CargarEmergencia = () => {
    let EmergenciaDTO = {};
    EmergenciaDTO.emergencia = txtEmergencia.value;
    EmergenciaDTO.fecha_Emergencia = DtpFEmergencia.value;
    EmergenciaDTO.id_Region = parseInt(cmbRegion.value);
    EmergenciaDTO.id_Tipo_Emergencia = parseInt(cmbTEmergencia.value);
    EmergenciaDTO.usuario = "super";
    return EmergenciaDTO;
}
const CargarMensaje =()=>{

    cmbRegion.value,txtEmergencia.value
}
//listener
frmEmergencia.addEventListener("submit", (e)=>{
    e.preventDefault();
});
const RegistrarAlerta = async ()=>{
    try {
        let url = "https://localhost:44374/Emergencias/RegistrarAlerta";
        let Response = await fetch(url,{
            method:"POST",
            body: JSON.stringify(CargarEmergencia()),
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            }
        })
        if(Response.ok && Response.status == 200) {
            alert("Emergencia enviada a los usuarios");
        }else{
            throw new Error(await Response.text());
        }
    }catch(ex){
        alert(ex);
    }

}
const EnviarAlerta = async ()=>{
    try {
        let url = "https://localhost:44374/EnvioAlerta/EnviarAlerta?IdRegion="+cmbRegion.value+"&Mensaje="+txtEmergencia.value;
        let Response = await fetch(url,{
            method:"POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            }
        })
        if(Response.ok && Response.status == 200) {
            alert("Alerta enviada a los usuarios");
        }else{
            throw new Error(await Response.text());
        }
    }catch(ex){
        alert(ex);
    }

}
btnRegistrarE.addEventListener("click",()=>{
    RegistrarAlerta();
    //EnviarAlerta();

})
//
window.addEventListener("load", async ()=>{
   await ListarRegiones();
   await ListarTipoEmergencia();
});