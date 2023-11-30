import React from 'react'
import { useState, useEffect } from 'react'
import axios from 'axios'
import { DataGrid, GridToolbar, esES } from '@mui/x-data-grid'
import { IconButton } from '@material-ui/core'
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import DeleteIcon from '@material-ui/icons/Delete'
import EditIcon from '@material-ui/icons/Edit'
import VisibilityIcon from '@material-ui/icons/Visibility'
import SearchIcon from '@material-ui/icons/Search'
import AddIcon from '@material-ui/icons/Add'


import {
  CButton,
  CCollapse,
  CCard,
  CCardBody,
  CForm,
  CFormLabel,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CFormSelect,
  CFormCheck,
  CFormFeedback,
  CCardHeader,
  CModal,
  CModalHeader,
  CModalTitle,
  CModalBody,
  CFormGroup,
  CFormRadio,
  CModalFooter,
  CContainer,
  CRow,
  CCol
}
  from '@coreui/react'
import { CardHeader } from 'reactstrap'

function Empleados() {
  const [empleados, setempleados] = useState([])
  const [sortModel, setSortModel] = useState([{ field: 'pren_Id', sort: 'asc' }])
  const user_Crea = parseInt(sessionStorage.getItem('usua_Id'));
  const [visible, setVisible] = useState(false) 
  const [Empleados, setEmpleadosDDL] = useState([]);
  
  const [data, setdata] = useState({
    suem_Id: '',
    sucu_Id: '',
    empl_Id: '',
    suem_Kilometros: '',
    usua_UsuarioCreacion: user_Crea
})

const handleSubmitI = (event) => {
  event.preventDefault()

  const config = {
      headers: {
          'Content-Type': 'application/json'
      }
  }
const form = event.currentTarget
if (form.checkValidity() === false) {
  event.preventDefault()
  event.stopPropagation()
  toast.error('No se permiten campos vacíos.');

}
if(form.checkValidity() != false){
  axios.post('Empleados/SucursalesEmpleado', data)
      .then((response) => {
        if (response.data.data.messagestatus == 2)
        {
          toast.error('El empleado ya está asignado a la sucursal seleccionada.');
        }
        else{
          console.log(response.data)
          toast.success('Registro ingresado correctamente.')};

      })
      .catch((error) => {
          console.log(error)
      })
    }
}

const NuevoRegistroE = (event) => {
  event.preventDefault()
  setdata({
    suem_Id: '',
    sucu_Id: '',
    empl_Id: '',
    suem_Kilometros: '',
    usua_UsuarioCreacion: user_Crea
}
)}
  
if (user_Crea==null ||  isNaN(user_Crea)) {
  window.location.href = '/';
}

const arregloJSONGET = sessionStorage.getItem("ArrayPantallas");
const ArrayPantallas = JSON.parse(arregloJSONGET);

const existeUsuarios = ArrayPantallas.some(objeto => objeto.name === "Empleados");

if (existeUsuarios) {
  
} else {
  window.location.href = '/#/Home';
}

 
  useEffect(() => {
    axios.get('Empleados/Listar').then((response) => {
      console.log(response.data);
      const insertarid = response.data.data.map((row) => ({
        ...row,
        id: row.empl_Id,
      }))
      setempleados(insertarid)
      setEmpleadosDDL(response.data.data)
    })
  }, [])

  const handleSortModelChange = (model) => {
    setSortModel(model)
  }

  const columns = [
    { field: 'empl_Id', headerName: 'ID', width: 90 },
    { field: 'empl_Nombres', headerName: 'Nombre', width: 150 },
    { field: 'empl_Apellidos', headerName: 'Apellido', width: 150 },
    { field: 'empl_DNI', headerName: 'DNI', width: 150 },
    { field: 'empl_Telefono', headerName: 'Telefono', width: 150 },
    
  ]

  return (
    <div style={{ width: '100%' }}>
      <div className='col-12'>
        <CCard className="p-5">
          <CCardHeader
          >
            <center>
            <img src='https://i.ibb.co/YXG4WrP/Headers.png' height={140}/>
            </center>
          </CCardHeader>


            <div className='col-2  mb-4'>
              <div className="d-grid gap-1">
                
                <CButton color="primary" variant="outline" onClick={() => setVisible(!visible)}>
                <AddIcon className="nav-icon ms-2 mb-1"  />Asignar
          </CButton>
              </div>
            </div>

          <DataGrid
            rows={empleados}
            columns={columns}
            sortModel={sortModel}
            onSortModelChange={handleSortModelChange}
            components={{
              Toolbar: GridToolbar,
              Search: SearchIcon,
            }}
            localeText={esES.components.MuiDataGrid.defaultProps.localeText}
          />

        <CModal
              alignment="center"
              visible={visible}
              onClose={() => setVisible(false)}
              aria-labelledby="Nuevo"
            >
              <CModalHeader>
                <CModalTitle id="Nuevo">Asignar sucursal a un empleado</CModalTitle>
              </CModalHeader>
              <CModalBody>
                <CForm>
                  <CContainer>
                    <CRow xs={{ cols: 2 }}>
                      <CCol>
                      <CFormSelect
                        value={data.empl_Id}
                        onChange={(e) =>
                            setdata({ ...data, empl_Id: e.target.value })
                        }
                        label="Empleado"
                        required>
                        <option value="">Seleccione un Empleado</option>
                        {Empleados.map((opcion) => (
                          <option style={{color: 'black'}} key={opcion.empl_Id} value={opcion.empl_Id}>
                            {opcion.empl_Nombre}
                          </option>
                        ))}
                      </CFormSelect>
                      </CCol>
                      <CCol>
                      <CFormSelect
                        value={data.empl_Id}
                        onChange={(e) =>
                            setdata({ ...data, empl_Id: e.target.value })
                        }
                        label="Sucursal"
                        required>
                        <option value="">Seleccione una Sucursal</option>
                        {Empleados.map((opcion) => (
                          <option style={{color: 'black'}} key={opcion.empl_Id} value={opcion.empl_Id}>
                            {opcion.empl_Nombre}
                          </option>
                        ))}
                      </CFormSelect>
                      </CCol>
                    </CRow>
                    <CRow>
                      <CCol>
                      <CFormInput
                        type="Nnumber"
                        label="Kilometros de distancia"
                        placeholder="Ingrese los kilometros de distancia"
                      />
                      </CCol>
                    </CRow>
                  </CContainer>
                 
                </CForm>
              </CModalBody>
              <CModalFooter>
                <CButton color="secondary" onClick={() => setVisible(false)}>
                  Cerrar
                </CButton>
                <CButton color="primary" onClick={() => handleSubmitI()}>Guardar</CButton>
              </CModalFooter>
            </CModal>
        
        </CCard>
      </div>
      <ToastContainer />

    </div>
  )
}

export default Empleados
