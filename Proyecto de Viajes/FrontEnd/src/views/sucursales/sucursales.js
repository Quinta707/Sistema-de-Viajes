import React from 'react'
import { useState, useEffect } from 'react'
import axios from 'axios'
import { DataGrid, GridToolbar, esES } from '@mui/x-data-grid'
import { IconButton} from '@material-ui/core'
import DeleteIcon from '@material-ui/icons/Delete'
import EditIcon from '@material-ui/icons/Edit'
import VisibilityIcon from '@material-ui/icons/Visibility'
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import SearchIcon from '@material-ui/icons/Search'
import AddIcon from '@material-ui/icons/Add'


import {CButton,
        CCollapse,
        CCard,
        CCardBody,
        CForm,
        CFormLabel,
        CCol,
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
        }
        from '@coreui/react'
import { CardHeader } from 'reactstrap'

function Sucursales() {
  const [Sucursales, setSucursales] = useState([])
  const [sortModel, setSortModel] = useState([{ field: 'prov_Id', sort: 'asc' }])
  const [visible, setVisible] = useState(false)
  const [visible2, setVisible2] = useState(false)
  const [Departamentos, setDepartamentosDDL] = useState([]);  
  const [Municipios, setMunicipiosDDL] = useState([]);  
  const [Modal, setModal] = useState(false)
  const [visibleEnca, setvisibleEnca   ] = useState(false)
  const user_Crea = parseInt(sessionStorage.getItem('usua_Id'));

  const [validated, setValidated] = useState(false)
  const handleSubmit = (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
    }
    setValidated(true)
  }

  
if (user_Crea==null ||  isNaN(user_Crea)) {
  window.location.href = '/';
}

const arregloJSONGET = sessionStorage.getItem("ArrayPantallas");
const ArrayPantallas = JSON.parse(arregloJSONGET);

const existeUsuarios = ArrayPantallas.some(objeto => objeto.name === "Sucursales");

if (existeUsuarios) {
  
} else {
  window.location.href = '/#/Home';
}
  const [nuevaSucursales, setnuevaSucursales] = useState({
    sucu_Nombre: '',
    muni_Id: '',
    sucu_Direccion: '',
    sucu_UserCrea:user_Crea,
})

const [dept_Id, setdept_Id] = useState({
    dept_Id: ''
})

const [ElimSucursales, setElimSucursales] = useState({
    sucu_Id: 0
  })

const [EditarSucursales, setEditarSucursales] = useState({
    sucu_Id:0,
    sucu_Nombre: '',
    muni_Id: '',
    sucu_Direccion: '',
    sucu_UserModifica:user_Crea,
})

const abrirPrenda = (params,event) => {
  if (event) {
    event.preventDefault()
  }
  setVisible2(!visible2)
  setValidated(false)
  setvisibleEnca(!visibleEnca)
  console.log(params)

  setEditarSucursales({
    sucu_Id:params.sucu_Id,
    sucu_Nombre: params.sucu_Nombre,
    dept_Id: params.dept_Id,
    muni_Id: params.muni_Id,
    sucu_Direccion: params.sucu_Direccion,
    sucu_UserModifica:user_Crea,    
})
}


const cerrarEditar = (event) => {
  event.preventDefault()
  setVisible2(!visible2)
  setvisibleEnca(!visibleEnca)
  setEditarSucursales({
    sucu_Id:0,
    sucu_Nombre: '',
    muni_Id: '',
    sucu_Direccion: '',
    sucu_UserModifica:user_Crea, 
})
}

const abrirycerrarInsert = (event) => {
  event.preventDefault()
  setVisible(!visible)
  setValidated(false)
  setvisibleEnca(!visibleEnca)
  setEditarSucursales({
    sucu_Id:0,
    sucu_Nombre: '',
    muni_Id: '',
    sucu_Direccion: '',
    sucu_UserModifica:user_Crea,
})

}

  //peticion a la api insert   
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
  setValidated(true)
  if(form.checkValidity() != false){
    axios.post('api/Sucursales/Insert', nuevaSucursales, config)
        .then((response) => {
          if (response.data.code == 409)
          {
            toast.error('La sucursal ya existe.');
          }
          else{
            console.log(response.data)
            setVisible(false)
            setvisibleEnca(!visibleEnca)
            setnuevaSucursales({
                sucu_Nombre: '',
                muni_Id: '',
                sucu_Direccion: '',
                sucu_UserCrea:user_Crea,
            })
            toast.success('Sucursal insertada correctamente.')};

        })
        .catch((error) => {
            console.log(error)
        })
      }
}

//peticion a la api Editar   
const handleSubmitE = (event) => {
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
  setValidated(true)
  if(form.checkValidity() != false){
  axios.put('api/Sucursales/Update', EditarSucursales, config)
      .then((response) => {
        if(response.data.code == 500){
          toast.error('Ya hay una sucursal con ese nombre')
        }
        else{
                    console.log(response.data)
          setVisible2(!visible2)
          setvisibleEnca(!visibleEnca)
          setEditarSucursales({
            sucu_Id: '',
            sucu_Nombre: '',
            muni_Id: '',
            sucu_Direccion: '',
            sucu_UserModifica:user_Crea,
        })
        toast.success('Sucursal editada correctamente.')
        }
;

        console.log(response.data)
      })
      .catch((error) => {
          console.log(error)
      })
    }
}


//peticion a la api Eliminar   
const handleSubmitD = (event) => {
    event.preventDefault()
  
    const config = {
        headers: {
            'Content-Type': 'application/json'
        }
    }
    axios.put('api/Sucursales/Delete', ElimSucursales, config)
        .then((response) => {
            console.log(response.data)
            setModal(false)
            setElimSucursales({
              sucu_Id: '',
          })
          toast.success('Sucursal eliminada correctamente.');

          console.log(response.data)
        })
        .catch((error) => {
            console.log(error)
        })
      
  }

  
  //enviar id del departamento   
  const enviarDeptId = (event,departamento) => {
    if (event) {
        event.preventDefault()
      }
    const config = {
        headers: {
            'Content-Type': 'application/json'
        }
    }
    console.log(departamento);
    axios.post('api/Municipios/ListarMunisDeptos',  departamento , config)
        .then((response) => {
            console.log(response.data)     
        setMunicipiosDDL(response.data);
        
        })
        .catch((error) => {
            console.log(error)
        })
}
      
  //peticion a la api listado   
  useEffect(() => {
    axios.get('api/Sucursales/Index').then((response) => {
      console.log('entra')
      const insertarid = response.data.map((row) => ({
        ...row,
        id: row.sucu_Id,
      }))
      setSucursales(insertarid)
    })
  }, [Sucursales])

  const handleSortModelChange = (model) => {
    setSortModel(model)
  }

  const columns = [
    { field: 'sucu_Id', headerName: 'ID',  width: 90},
    { field: 'sucu_Nombre', headerName: 'Nombre',  width: 150},
    { field: 'dept_Descripcion', headerName: 'Departamento',  width: 150},
    { field: 'muni_Descripcion', headerName: 'Municipio',  width: 150},
    { field: 'sucu_Direccion', headerName: 'Dirección',  width: 150},

    {
      field: 'acciones',
      headerName: 'Acciones',
      width: 300,
      renderCell: (params) => (
        <div>
      
        
            <CButton  color="info ms-2" variant="outline">
            <VisibilityIcon />
          </CButton>

          <CButton color="warning ms-2" variant="outline" onClick={(e) => {
    abrirPrenda(params.row, e);
    setdept_Id(prevDept_Id => {
        const newDept_Id = { ...prevDept_Id, dept_Id:  params.row.dept_Id };
        enviarDeptId(e, newDept_Id); // llamada a la función que envía el dept_Id a la API
        return newDept_Id;
    });
    }}>
    <EditIcon />
        </CButton>

          
        <CButton color="danger ms-2" variant="outline" onClick={() => ModalFun(params.row.sucu_Id)}>
            <DeleteIcon />
            </CButton>
        
        </div>
      ),
    },
  ]

  const ModalFun = (params,event)=>{
    if (event) {
      event.preventDefault()
    }
    setModal(!visible)
    setElimSucursales({
      sucu_Id: params,
     
  })
  }

  useEffect(() => {
    axios.get('api/Departamentos/Index')
    .then(response => {
      setDepartamentosDDL(response.data);
      console.log(response.data)     

    })
    .catch(error => { 
      console.error('Error fetching data from API:', error);
    });



  }, []);



  return (
    <div style={{ width: '100%' }}>
      <div className='col-12'>
    <CCard className="p-5">
    <CCardHeader className='rounded-top mb-4' style={{ fontFamily: "revert-layer",  textAlign: 'center', fontSize: 50   }}>Sucursales</CCardHeader>
      <CCollapse visible={!visibleEnca}>

    {/*Modal Eliminar*/}

    <CModal alignment="center"  visible={Modal} onClick={() => setModal(!Modal)}>
      
      <CModalBody className='pt-5 pb-5' style={{boxShadow:5}}>
      <CForm
    className="row g-3 needs-validation"
    noValidate
    validated={validated}
    onSubmit={handleSubmitD}
>
      <CFormInput
      minLength={2} maxLength={2}
        type="hidden"
    value={ElimSucursales.sucu_Id}
    id="validationCustom01"
    disabled
    required/>
            <center>
        <CModalTitle>Esta seguro que desea Eliminar este registro?</CModalTitle>
        </center>
    <center>
     <CButton color="light"  className='col-5 me-3' onClick={() => setModal(!Modal)}>
          Cancelar
        </CButton>
        <CButton color="danger text-light" type='submit' className='col-5'>Eliminar</CButton>
    </center>
    </CForm>
      </CModalBody>
      
    </CModal>

      <div className='col-2  mb-4'>
      <div className="d-grid gap-1">

    <CButton color="primary" variant="outline" href="#"        
    onClick={abrirycerrarInsert}  className="ml-auto">
       <AddIcon  className="nav-icon ms-2 mb-1" />
      Nuevo
    </CButton>
          </div>
      </div>
    </CCollapse>

 {/*Formulario Insertar*/}
 
    <CCollapse visible={visible} className='col-12'>
    
      <CCard className="mt-3">
        <CCardHeader>
          <h1 className='h3 text-center'>Nueva Sucursal</h1>
        </CCardHeader>
        <CCardBody>
      <CForm
    className="row g-3 needs-validation"
    noValidate
    validated={validated}
    onSubmit={handleSubmitI}
>


       <CCol md={6} className=''>

        <CFormInput
    type="text"
    value={nuevaSucursales.sucu_Nombre}
    onChange={(e) => setnuevaSucursales({ ...nuevaSucursales, sucu_Nombre: e.target.value })}
    id="validationCustom01"
    label="Nombres"
    required/>

    </CCol>









    

    <CCol md={6} className="">
    <CFormSelect
  value={dept_Id.dept_Id}
  onChange={(e) => {
    setdept_Id(prevDept_Id => {
      const newDept_Id = { ...prevDept_Id, dept_Id:  e.target.value };
      enviarDeptId(e, newDept_Id); // llamada a la función que envía el dept_Id a la API
      return newDept_Id;
    });
  }}
  id="validationCustom01"
  label="Departamento"
  required
>
  <option value="">Seleccione un Departamento</option>
  {Departamentos.map((opcion) => (
    <option key={opcion.dept_Id} value={opcion.dept_Id}>
      {opcion.dept_Descripcion}
    </option>
  ))}
</CFormSelect>


</CCol>

<CCol md={6} className="">
  <CFormSelect
    value={nuevaSucursales.muni_Id}
    onChange={(e) =>
        setnuevaSucursales({ ...nuevaSucursales, muni_Id: e.target.value })
    }
    id="validationCustom01"
    label="Municipio"
    required>
    <option value="">Seleccione un Municipio</option>
    {Municipios.map((opcion) => (
      <option key={opcion.muni_Id} value={opcion.muni_Id    }>
        {opcion.muni_Descripcion}
      </option>
    ))}
  </CFormSelect>

</CCol>




<CCol md={6} className=''>

<CFormInput
type="text"
value={nuevaSucursales.sucu_Direccion}
onChange={(e) => setnuevaSucursales({ ...nuevaSucursales, sucu_Direccion: e.target.value })}
id="validationCustom01"
label="Dirección"
required/>

</CCol>


    <CCol xs={12} className='offset-4'>
      <CButton color="primary"  type="submit">
        Guardar
      </CButton>
      <CButton color="danger text-light"  className='ms-2' href="#" onClick={abrirycerrarInsert}>
      Cancelar
    </CButton>
    </CCol>
  </CForm>
        </CCardBody>
      </CCard>
    </CCollapse>


 {/*Formulario Editar*/}
    <CCollapse visible={visible2} className='col-12 '>
    
    <CCard className="mt-3">
      <CCardHeader>
        <h1 className='h3 text-center'>Editar Sucursal</h1>
      </CCardHeader>
      <CCardBody>
    <CForm
  className="row g-3 needs-validation"
  noValidate
  validated={validated}
  onSubmit={handleSubmitE}
>

<CCol md={0} className=''>
<CFormInput
type="hidden"
value={EditarSucursales.sucu_Id}
onChange={(e) => setEditarSucursales({ ...EditarSucursales, sucu_Id: e.target.value })}
required/>

</CCol>


<CCol md={6} className=''>

<CFormInput
type="text"
value={EditarSucursales.sucu_Nombre}
onChange={(e) => setEditarSucursales({ ...EditarSucursales, sucu_Nombre: e.target.value })}
id="validationCustom01"
label="Nombre"
required/>

</CCol>










<CCol md={6} className="">
<CFormSelect
value={EditarSucursales.dept_Id}
onChange={(e) => {
setdept_Id(prevDept_Id => {
const newDept_Id = { ...prevDept_Id, dept_Id:  e.target.value };
enviarDeptId(e, newDept_Id); // llamada a la función que envía el dept_Id a la API
return newDept_Id;
});
}}
id="validationCustom01"
label="Departamento"
required
>
<option value="">Seleccione un Departamento</option>
{Departamentos.map((opcion) => (
<option key={opcion.dept_Id} value={opcion.dept_Id}>
{opcion.dept_Descripcion}
</option>
))}
</CFormSelect>


</CCol>

<CCol md={6} className="">
<CFormSelect
value={EditarSucursales.muni_Id}
onChange={(e) =>
setEditarSucursales({ ...EditarSucursales, muni_Id: e.target.value })
}
id="validationCustom01"
label="Municipio"
required>
<option value="">Seleccione un Municipio</option>
{Municipios.map((opcion) => (
<option key={opcion.muni_Id} value={opcion.muni_Id    }>
{opcion.muni_Descripcion}
</option>
))}
</CFormSelect>

</CCol>



<CCol md={6} className=''>

<CFormInput
type="text"
value={EditarSucursales.sucu_Direccion}
onChange={(e) => setEditarSucursales({ ...EditarSucursales, sucu_Direccion: e.target.value })}
id="validationCustom01"
label="Dirección"
required/>

</CCol>





  <CCol xs={12} className='offset-4'>
    <CButton color="primary" type="submit">
      Guardar
    </CButton>
    <CButton color="danger text-light" className='ms-2' href="#"  onClick={cerrarEditar}>
      Cancelar
    </CButton>
  </CCol>
</CForm>
      </CCardBody>
    </CCard>
  </CCollapse>


      <CCollapse visible={!visibleEnca}>
    <CCard className="mt-3 p-1">

      <DataGrid
        rows={Sucursales}
        columns={columns}
        sortModel={sortModel}
        onSortModelChange={handleSortModelChange}
        components={{
          Toolbar: GridToolbar,
          Search: SearchIcon,
        }}
        localeText={esES.components.MuiDataGrid.defaultProps.localeText}
      />
      </CCard>
      </CCollapse>
      </CCard>
      </div>
      <ToastContainer />

    </div>
  )
}

export default Sucursales
