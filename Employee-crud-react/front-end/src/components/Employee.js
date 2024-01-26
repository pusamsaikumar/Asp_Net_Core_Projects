import axios from 'axios';
import React,{useState,useEffect} from 'react';
import { Modal ,Form, Button} from 'react-bootstrap';
import { AiFillDelete,AiFillEdit} from "react-icons/ai";
import { Variable } from '../Variable';


const  Employee= () => {
  const [dept,setDept] = useState([]);
 

  const [val,setVal] = useState({
    modelTitle:"",
    departments:[],
    employees:[],
    EmployeeId: 0,
    EmployeeName: "",
    Department: "",
    DateOfJoining: "",
    PhotoFileName:"ecommerce.webp",
    Photopath: Variable.PHOTO_URL
  });

  const handleInput =(e,name) =>{
    setVal({
      deptName:e.target.value
    })
  }
  useEffect(()=>{
  getDepartmentdata();
 
  },[]);
  
  const getDepartmentdata = async ()=>{
    await axios.get("https://localhost:7286/api/Employee").then((res) =>setVal({employees:res.data}) ).catch(err=>{})
  }
 

  const deleteClick= async(each)=>{
   var config={
    method:"DELETE",
    //url:Variable.API_URL+'Department'+`/${each.EmployeeId}`,
    url:"https://localhost:7286/api/Employee/"+ each.EmployeeId
   }
   await axios(config).
   then(res => {
    alert(res.data) ;
    getDepartmentdata()
   }).catch(err => alert("failed"))
  }
  const [show,setShow] = useState(false);

 

 
function Models({show,setShow,val,setVal,handleInput, getDepartmentdata }){

const [value,setValue] = useState(val);
const [empId,setEmpId]= useState(val.EmployeeId);
const [empName,setEmpName] = useState(val.EmployeeName);
const [dept,setDept] = useState(val.Department);
const [doj,setDoj] = useState(val.DateOfJoining);
const[fileName,setFileName] = useState(val.PhotoFileName);

console.log("em",empName, "dep", dept, "do",doj,"ne",fileName)

const createDept= async(e)=>{
  e.preventDefault()
  var config={
    method:"POST",
    url:Variable.API_URL+'Employee',
    headers:{
      'Accept':'application/json',
      'Content-Type':'application/json'
    },
    data:JSON.stringify({
      EmployeeName:empName,
      Department:dept,
      DateOfJoining:doj,
      PhotoFileName:fileName
    })
 
  }

  console.log("congi",config.data)
  await axios(config).then((res) =>{
    console.log("create ",res)
    getDepartmentdata();
    setVal({EmployeeId:0})
    setEmpId(0);
    setShow(false);
  }).catch((error)=> alert("Failed"))
}

const updateDept=async(e)=>{
e.preventDefault();
  var config={
    method:"PUT",
    url:Variable.API_URL+'Employee',
    headers:{
      'Accept':"application/json",
      'Content-Type':"application/json"
    },
    data:JSON.stringify({
      EmployeeId: empId,
      EmployeeName:empName,
      Department:dept,
      DateOfJoining:doj,
      PhotoFileName:fileName
    })
  };
  await axios(config).then((res) => 
  {
    alert(res.data);
    getDepartmentdata();
    setDept("");
    setDoj("");
    setEmpId(0);
    setEmpName("");
    setFileName("");
    // setValue({
      
    //     EmployeeId: "",
    //   EmployeeName: "",
    //   Department: "",
    //   DateOfJoining: "",
    //   PhotoFileName:"",
    
    // });
    // setVal({
    //   EmployeeId: "",
    // EmployeeName: "",
    // Department: "",
    // DateOfJoining: "",
    // PhotoFileName:"",
    // })
    setShow(false)
  }


  ).catch(err => alert("failed"))
}

const uploadImg=async(e)=>{
  const dataform = new FormData();
  dataform.append("file",e.target.files[0],e.target.files[0].name)
  var config={
    method:"POST",
    url:Variable.API_URL+'Employee/SaveFile',
    data:dataform
  }
  await axios(config).then((res) => setFileName(res.data))
}





  return <>
      <Modal
        size='lg'
        onHide={()=> setShow(false)}
        show={show} 
       // aria-labelledby="example"
        //className='modal-dialog modal-dialog-centered'
      >
          <Modal.Header closeButton>
              <Modal.Title id="example">
                  {val.modelTitle}
              </Modal.Title>
          </Modal.Header>
          <Modal.Body>
       

<Form>
<div className='d-flex flex-row  mb-3' >
          <div className='p-2 w-50'>
          <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
            <Form.Label>Employee Name</Form.Label>
            <input
              type="text"
              placeholder="Enter Employee Name"
               value={empName}
               name="empName"
               className='form-control'
               onChange={(e) => 
              setEmpName( e.target.value)
              }
            
            />
            
            <Form.Label>Department</Form.Label>
            <Form.Control
             type="text"
             value={dept}
             placeholder="Enter Department Name"
             name="dept"
             onChange={(e) => setDept(e.target.value)}
            
            />
         
           


            <Form.Label>DateOfJoining</Form.Label>
            <input type='date' className='form-control' value={doj} naem="doj"
            
            onChange={(e) => setDoj(e.target.value)}
            />

           
            
          </Form.Group>
          </div>
          
     
           
          <div className='p-2 w-50'> 
          <img src={Variable.PHOTO_URL+fileName} alt={fileName} style={{width:"100px",height:"100px",borderRadius:"50px",marginBottom:"10px"}} />
            <input type="file" onChange={(e) => uploadImg(e)} />
          </div>
             
          </div>
       
         </Form>
   
         
            {
              val.EmployeeId === 0 ? <>
              <Button type="submit" style={{marginTop:"10px"}} onClick={(e)=>createDept(e)} >Create</Button>
              </> : null
            }
            {
               val.EmployeeId !==0 ? <>
            <Button style={{marginTop:"10px"}} type='submit' onClick={(e)=>updateDept(e)}>Update</Button>
              </> : null
            }
          </Modal.Body>
      </Modal>
  </>
}

const addClick=()=>{
 
  setShow(true);

 
}
 const editClick=(each)=>{
  setShow(true);
  setVal({
 
    modelTitle:"Edit Employee",
    EmployeeId: each.EmployeeId,
    EmployeeName: each.EmployeeName,
    Department: each.Department,
    DateOfJoining:each.DateOfJoining,
    PhotoFileName:each.PhotoFileName,
  
  });
 
 }

  return (
    <div>
   <Button type="button" onClick={()=>{
        addClick();
        setVal({
            ...val,
          modelTitle:"Add Employee",
          EmployeeId: 0,
    EmployeeName: "",
    Department: "",
    DateOfJoining: "",
    PhotoFileName:"ecommerce.webp",
       
        });
      }}
       className='float-end' aria-labelledby="example">Add Emmployee</Button>
      <div>
        <table className='table table-striped' > 
          <thead>
                <tr>
                  <th>Employee Id</th>
                  <th>Employee Name</th>
                  <th>Department</th>
                  <th>Doj</th>
                  <th>Options</th>
                </tr>
          </thead>
          <tbody>
            {
              val?.employees?.map((each) => <tr key={each.DepartmentId}>
                  <td>{each.EmployeeId}</td>
                  <td>{each.EmployeeName}</td>
                  <td>{each.Department}</td>
                  <td>{each.DateOfJoining}</td>
                  <td>
                    <button type="submit" 
                    className="btn btn-secondary mr-20" style={{marginRight:"10px"}}
                    onClick={()=>editClick(each)}
                    >{<AiFillEdit />}</button>
                    <button type="submit" className="btn btn-primary mr-10"
                      onClick={()=>deleteClick(each)}  >{<AiFillDelete />}</button>
                  </td>
              </tr>)
            }
          </tbody>
        </table>
    </div>
    <div>
      <Models  show={show} setShow={ setShow} val={val} setVal={setVal} handleInput={handleInput} getDepartmentdata={getDepartmentdata} />
    </div>
    </div>
  )
}

export default Employee;
