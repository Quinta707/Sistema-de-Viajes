import React from "react";
import CIcon from "@coreui/icons-react";

//import de los iconos a usar en la navbar
import {
  cilHome,
  cilBank,
  cilLockLocked,
  cibLibreoffice,
  cilCash,
} from "@coreui/icons";
import { CNavGroup, CNavItem, CNavTitle } from "@coreui/react";



const arregloJSONGET = sessionStorage.getItem("ArrayPantallas");
const ArrayPantallas = JSON.parse(arregloJSONGET);
console.log(ArrayPantallas);



const Rrhh_Items = [];
const Gral_Items = [];
const Acce_Items = [];
const Viaj_Items = [];

const Menu  = [];

const user_Crea = parseInt(parseInt(sessionStorage.getItem('usua_Id')));

if (user_Crea==null ||  isNaN(user_Crea)) {
  window.location.href = '/';
}
if (ArrayPantallas==null){
  console.log("Error en ArrayPantallas")
}
else{
ArrayPantallas.forEach((element) => {
  if(element.identificador == "acce"){
    Acce_Items.push({
    component: CNavItem,
    name: element.name,
    to: element.to,
    })
  }
  if(element.identificador == "gral"){
    Gral_Items.push({
    component: CNavItem,
    name: element.name,
    to: element.to,
    })
  }
  if(element.identificador == "rrhh"){
    Rrhh_Items.push({
    component: CNavItem,
    name: element.name,
    to: element.to,
    })
  }
  if(element.identificador == "viaj"){
    Viaj_Items.push({
    component: CNavItem,
    name: element.name,
    to: element.to,
    })
  }
});
}


if(Acce_Items.length!=0){
  
  Menu.push (
  {
    component: CNavTitle,
    name: 'Accesos',
  },
  {
  component: CNavGroup,
  name: 'Acceso',
  to: '/base',
  icon: <CIcon icon={cilLockLocked} customClassName="nav-icon" />,
  items: [...Acce_Items]
})

}
if(Gral_Items.length!=0){

  Menu.push (
    {
      component: CNavTitle,
      name: 'Generales',
    },
    {
    component: CNavGroup,
    name: 'General',
    to: '/base',
    icon: <CIcon icon={cibLibreoffice} customClassName="nav-icon" />,
    items: [...Gral_Items]
  })

}
if(Rrhh_Items.length!=0){
  Menu.push (
    {
      component: CNavTitle,
      name: 'Recursos Humanos',
    },
    {
    component: CNavGroup,
    name: 'RRHH',
    to: '/base',
    icon: <CIcon icon={cilBank} customClassName="nav-icon" />,
    items: [...Rrhh_Items]
  })
}
if(Viaj_Items.length!=0){
  Menu.push (
    {
      component: CNavTitle,
      name: 'Viajes',
    },
    {
    component: CNavGroup,
    name: 'Viaje',
    to: '/base',
    icon: <CIcon icon={cilCash} customClassName="nav-icon" />,
    items: [...Viaj_Items]
  })
}




const pantalla = [
  {
    component: CNavItem,
    name: "Inicio",
    to: "/home",
    icon: <CIcon icon={cilHome} customClassName="nav-icon" />,
  },
  ...Menu
];




const _nav = pantalla;

export default _nav;
