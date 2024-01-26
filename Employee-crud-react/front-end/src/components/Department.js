import axios from 'axios';
import React, { useState, useEffect } from 'react';
import { Modal, Form, Button } from 'react-bootstrap';
import { AiFillDelete, AiFillEdit, AiOutlineArrowUp, AiOutlineArrowDown } from "react-icons/ai";
import { Variable } from '../Variable';


const Department = () => {
  const [dept, setDept] = useState([]);


  const [val, setVal] = useState({
    modelTitle: "",
    deptName: "",
    deptId: 0,

  });


  useEffect(() => {
    getDepartmentdata();
  }, []);
  const getDepartmentdata = async () => {
    await axios.get("https://localhost:7286/api/Department").then(
      (res) => {
        setDept(res.data);
        setVal({ withoutFilterdepts: res.data })
      })
  }

  // filter search function:



  const handleInput = (e, name) => {
    setVal({
      deptName: e.target.value
    })
  }


  const deleteClick = async (each) => {
    var config = {
      method: "DELETE",
      url: Variable.API_URL + 'Department' + `/${each.DepartmentId}`,

    }
    await axios(config).
      then(res => {
        alert(res.data);
        getDepartmentdata()
      }).catch(err => alert("failed"))
  }
  const [show, setShow] = useState(false);




  function Models({ show, setShow, val, setVal, handleInput, getDepartmentdata }) {
    // const [val,setVal]=useState(val);
    const [value, setValue] = useState(val);

    const createDept = async (e) => {
      e.preventDefault()
      var config = {
        method: "POST",
        url: Variable.API_URL + 'Department',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        data: JSON.stringify({
          DepartmentName: value.deptName
        })

      }
      await axios(config).then((res) => {
        getDepartmentdata();
        setShow(false);
      }).catch((error) => alert("Failed"))
    }

    const updateDept = async (e) => {
      e.preventDefault();
      var config = {
        method: "PUT",
        url: Variable.API_URL + 'Department',
        headers: {
          'Accept': "application/json",
          'Content-Type': "application/json"
        },
        data: JSON.stringify({
          DepartmentId: value.deptId,
          DepartmentName: value.deptName
        })
      };
      await axios(config).then((res) => {
        alert(res.data);
        getDepartmentdata();
        setValue({
          deptId: "",
          deptName: ""
        });
        setVal({
          deptId: "",
          deptName: ""
        })
        setShow(false)
      }


      ).catch(err => alert("failed"))
    }

    //console.log("val",val);

    console.log("value", value)
    return <>
      <Modal
        size='lg'
        onHide={() => setShow(false)}
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
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
              <Form.Label>Department Name</Form.Label>
              <input
                type="text"
                placeholder="Enter Department Name"
                value={value.deptName}
                name="deptName"
                className='form-control'
                onChange={(e) => {

                  setValue({
                    ...value,
                    deptName: e.target.value
                  })
                }}

              />
            </Form.Group>
          </Form>
          {
            val.deptId === 0 ? <>
              <Button type="submit" style={{ marginTop: "10px" }} onClick={(e) => createDept(e)} >Create</Button>
            </> : null
          }
          {
            val.deptId !== 0 ? <>
              <Button style={{ marginTop: "10px" }} type='submit' onClick={(e) => updateDept(e)}>Update</Button>
            </> : null
          }
        </Modal.Body>
      </Modal>
    </>
  }

  const addClick = () => {

    setShow(true);

    setVal({

      modelTitle: "Add Department",
      deptId: 0,
      deptName: "",

    });
  }
  const editClick = (each) => {
    setShow(true);
    setVal({

      modelTitle: "Edit Department",
      deptId: each.DepartmentId,
      deptName: each.DepartmentName,

    });

  }


  const [searchId, setSeacrhId] = useState("");
  const [searchName, setSearchName] = useState("");

  const [sorted,setSorted] = useState({sorted:"DepartmentId",reversed:false})

// sort by id 

const sortById=()=>{
  let deptCopy = [...dept];
  deptCopy.sort((deptA,deptB) => {
  //  if(sorted.reversed){
      return deptA.DepartmentId - deptB.DepartmentId
  //  }
   //  return deptB.DepartmentId - deptA.DepartmentId;
  });
  setDept(deptCopy);
  //setSorted({sorted:"DepartmentId",reversed:!sorted.reversed})
}

// sort by desc order
const sortByIdDec=()=>{
  let deptCopy = [...dept];
  deptCopy.sort((deptA,deptB) => {
  //  if(sorted.reversed){
      return deptB.DepartmentId - deptA.DepartmentId
  //  }
  //   return deptA.DepartmentId - deptB.DepartmentId;
  });
  setDept(deptCopy);
 // setSorted({sorted:"DepartmentId",reversed:!sorted.reversed})
}

// sortby Dept NAME:
const sortByNameAcs=()=>{
  let DeptCopy = [...dept];
  DeptCopy.sort((deptA,deptB) => {
    return `${deptA.DepartmentName}`.localeCompare(`${deptB.DepartmentName}`);
  })
  setDept(DeptCopy);
}
const sortByNamedecs=()=>{
  let DeptCopy = [...dept];
  DeptCopy.sort((deptA,deptB) => {
   return `${deptB.DepartmentName}`.localeCompare(`${deptA.DepartmentName}`)
  })
  setDept(DeptCopy);
}

  //search by id
  const handleIdSearch = (e) => {
    let searchData = dept.filter((each) => {
      return `${each.DepartmentId}`.toLocaleLowerCase().includes(e.target.value.toLocaleLowerCase())
    }
    );
    if (e.target.value.length > 0) {
      setDept(searchData);
    }
    setSeacrhId(e.target.value)
  }

  //search by name
  const handleNameSearch = (e) => {

    let nameSearch = dept.filter((each) => {
      return `${each.DepartmentName}`.toLocaleLowerCase().includes(e.target.value.toLocaleLowerCase())
    });
    if (e.target.value.length > 0) {
      setDept(nameSearch);
    }
    setSearchName(e.target.value)
  }

  return (
    <div>
      <Button type="button" onClick={() => {
        addClick();
        setVal({ ...val, deptName: '', deptId: 0, modelTitle: "Add Department" });
      }}
        className='float-end' aria-labelledby="example">Add Department</Button>
      <div>
        <table className='table table-striped' >
          <thead>
            <tr>
              <th>
                <div className='d-flex flex-row'>
                  <Form.Control
                    type='text'
                    placeholder='Search By Id ...'
                    value={searchId}
                    onChange={(e) => handleIdSearch(e)}
                  />
                  <Button type='button' className='btn btn-light' onClick={sortById}>
                    <AiOutlineArrowUp />
                  </Button>
                  <Button type='button' className='btn btn-light' onClick={sortByIdDec}>
                    <AiOutlineArrowDown />
                  </Button>

                </div>

                Department Id</th>
              <th>
                <div className='d-flex flex-row'>
                  <Form.Control
                    type='text'
                    placeholder='Search By Name....'
                    value={searchName}
                    onChange={(e) => handleNameSearch(e)}
                  />
                  <Button type='button' className='btn btn-light' onClick={sortByNameAcs}>
                    <AiOutlineArrowUp />
                  </Button>
                  <Button type='button' className='btn btn-light' onClick={sortByNamedecs}>
                    <AiOutlineArrowDown />
                  </Button>
                </div>

                Department Name
              </th>
              <th>Options</th>
            </tr>
          </thead>
          <tbody>
            {
              dept?.map((each) => <tr key={each.DepartmentId}>
                <td>{each.DepartmentId}</td>
                <td>{each.DepartmentName}</td>
                <td>
                  <button type="submit"
                    className="btn btn-secondary mr-20" style={{ marginRight: "10px" }}
                    onClick={() => editClick(each)}
                  >{<AiFillEdit />}</button>
                  <button type="submit" className="btn btn-primary mr-10"
                    onClick={() => deleteClick(each)}  >{<AiFillDelete />}</button>
                </td>
              </tr>)
            }
          </tbody>
        </table>
      </div>
      <div>
        <Models show={show} setShow={setShow} val={val} setVal={setVal} handleInput={handleInput} getDepartmentdata={getDepartmentdata} />
      </div>
    </div>
  )
}

export default Department
