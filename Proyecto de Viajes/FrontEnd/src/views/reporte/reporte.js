import React, { useEffect, useState } from 'react';
import jsPDF from 'jspdf';
import 'jspdf-autotable';
import axios from 'axios';

function PDFDocument() {
  // creamos el documento PDF
  const doc = new jsPDF();

  const user_Crea = parseInt(sessionStorage.getItem('usua_Id'));

  
if (user_Crea==null ||  isNaN(user_Crea)) {
    window.location.href = '/';
  }
  
  const arregloJSONGET = sessionStorage.getItem("ArrayPantallas");
  const ArrayPantallas = JSON.parse(arregloJSONGET);
  
  const existeUsuarios = ArrayPantallas.some(objeto => objeto.name === "Reporte");
  
  if (existeUsuarios) {
    
  } else {
    window.location.href = '/#/Home';
  }

    const [data, setData] = useState([]);
    useEffect(() => {
      const fetchData = () => {
          axios.get("api/Reporte/Info")
            .then(response => {
              setData(response.data)

            })
            .catch(error => {
              console.log('Error en la solicitud Axios:', error);
            });
          };
   
          fetchData();
    }, []);

    const header = function (data) {
      doc.setFontSize(18);
      const pageWidth = doc.internal.pageSize.width;
      doc.setTextColor(40);
    
      // Agregar imagen
      doc.addImage('https://i.ibb.co/PcBVMyb/Logo.jpg', 'JPG',  pageWidth-40,5, 24, 24);

    
      // Agregar texto
      doc.text("Reporte de Ventas Diarias", data.settings.margin.left + 0, 22);
    };

      const footer = function (data) {
        const pageCount = doc.internal.getNumberOfPages();
        const currentPage = data.pageNumber;
        const pageWidth = doc.internal.pageSize.width;
        const date = new Date().toLocaleDateString('es-ES', { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' });
        const text = `Documento generado por IsHatake el ${date}`;
        const textWidth = doc.getTextWidth(text);
        const textX = (pageWidth*1.3) - textWidth;
        doc.setFontSize(10);
        doc.text(`Página ${currentPage}`, data.settings.margin.left, doc.internal.pageSize.height - 10);
        doc.text(text, textX, doc.internal.pageSize.height - 10);
      };
      
  //  doc.autoTableAddPage({
  //    addPageContent: header,
  //  });

  // añadimos contenido al PDF utilizando jspdf-autotable
  doc.autoTable({
    head: [['Fecha', 'Cantidad de Ventas del Dia','Total del Día']],
    body: data.map((row) => [
      row.fecha,
      row.total_Ventas_Al_Dia,
      row.total_Dia,
    ]),    
    didDrawPage: function (data) {
        header(data);
        // agregamos la paginación
        footer(data);
      },
      margin: { top: 30, bottom:20 } 
  });

  // obtenemos una URL del PDF para mostrarlo en un iframe
  const pdfUrl = doc.output('dataurl');

  // mostramos el documento PDF en un iframe
  return (
    <div style={{ height: '100vh' }}>
      <iframe src={pdfUrl} style={{ width: '100%', height: '100%' }} />
    </div>
  );
}

export default PDFDocument;