import { useState, useEffect } from 'react'
import React from 'react'
import { Link , useNavigate} from 'react-router-dom'
import {
  CButton,
  CCard,
  CCardBody,
  CCardGroup,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CRow,
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'
import axios from 'axios'
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { CardHeader } from 'reactstrap'

const Login = () => {
  const navigate = useNavigate();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [si, setsi] = useState(true);

  const handleSubmit = (e) => {
    e.preventDefault();
    // setLoading(true);
    setError('');
    if(username.length==0 ){
      toast.warning("Usuario es requerido");
      setLoading(false);
      setsi(false)
    }

    if(password.length==0){
      toast.warning("Contraseña es requerida");
      setLoading(false);
      setsi(false)
    }
    if(password.length!=0 && username.length!=0 ){
      let datos = {
        "usua_Nombre": username,
        "usua_Contrasenia": password,
    }
      axios.post('Usuarios/Login', datos)
      .then((response) => {
        if(response.data.usua_Id!=0){
          console.log(response.data)
          sessionStorage.setItem("usua_Id", response.data.data.usua_Id);
          sessionStorage.setItem("usua_Nombre", response.data.data.usua_Nombre);
          sessionStorage.setItem("empl_Id", response.data.data.empl_Id);
          //console.log(response.data.data.usua_Nombre);
          setUsername("");
          setPassword("");
          const usua_Id = parseInt(sessionStorage.getItem('usua_Id'));
      console.log(usua_Id);
      axios
          .get(`Usuarios/DibujadoMenu?id=${usua_Id}`)
          .then((response) => {
            const menu = response.data.map((item) => ({
              name: item.pant_Nombre,
              to: item.pant_href,
              identificador: item.pant_Identificador.substring(0, 4),
            }));
          
            console.log(menu);
            const arregloJSON = JSON.stringify(menu);
          
            sessionStorage.setItem('ArrayPantallas', arregloJSON);
          
            navigate('/home');
    
            })
            .catch((error) => {
              console.log(error);
            });
        }
        else{
          toast.error("El usuario o la contraseña son incorrectos");
        }
      })
      .catch((error) => {
        toast.error("El usuario o la contraseña son incorrectos");
        setError(error.message); 
      })
      .finally(() => {
      });
      
      }
  };

  return (
    <div className="bg-light min-vh-100 d-flex flex-row align-items-center" style={{backgroundImage: "url('https://i.ibb.co/3pHcSVy/fondo-1.png')",backgroundSize:'cover',backgroundRepeat:'no-repeat'}}>
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={6}>
            <CCardGroup>
              <CCard className="p-4 pb-5 pt-5" style={{backgroundColor: 'rgba(255, 255, 255, 100)', backgroundSize: 'cover', backgroundRepeat: 'no-repeat'}}>
                <div className='CardHeader  align-items-center'>
                <center>
                <img height={140} src='https://i.ibb.co/h2s0RcT/logo.png'/>
                    <h1 className='h1 mt-5' style={{color: 'rgba(160, 103, 204, 100)'}}>INICIAR SESION</h1>
                    </center>
                </div>
                <CCardBody>
                  <CForm onSubmit={handleSubmit}>
                    <CInputGroup className="mb-3">
                      <CInputGroupText>
                        <CIcon icon={cilUser} />
                      </CInputGroupText>
                      <CFormInput
                        placeholder="Usuario"
                        autoComplete="Usuario"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        
                      />
                    </CInputGroup>
                    <CInputGroup className="mb-4">
                      <CInputGroupText>
                        <CIcon icon={cilLockLocked} />
                      </CInputGroupText>
                      <CFormInput
                        type="password"
                        placeholder="Contraseña"
                        autoComplete="current-password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        
                      />
                    </CInputGroup>
                    <CRow>
                      <center>
                      <CCol xs={6}>
                        <CButton type="submit" color="dark lg" variant='outline' style={{border: '1px solid'}} className="px-4 btn-lg" >
                          {loading ? 'Iniciando Sesión...' : 'Iniciar Sesión'}
                        </CButton>
                      </CCol>
                      <CCol xs={6} className="text-right">
                        
                      </CCol>
                      </center>
                    </CRow>
                  </CForm>
                </CCardBody>
              </CCard>  
             
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
      <ToastContainer />
    </div>
  )
}

export default Login
