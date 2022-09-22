import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import EditIcon from '@mui/icons-material/Edit';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import axios from 'axios';
import Navbar from '../components/navbar';
import { Button, Typography } from '@mui/material';
import { useState,useEffect } from 'react';
import { DeleteForever } from '@mui/icons-material';

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));

export default function Home() {
  const [datafield,setDatafield] = useState([]);
  useEffect(() => {
    axios.get('http://localhost:11738/Medewerker').then(response=>{
      console.log(response.data);
      setDatafield(
        response.data.map((row,key) => (
            <StyledTableRow key={key}>
              <StyledTableCell component="th" scope="row">
              {row.naam}
              </StyledTableCell>
              <StyledTableCell >{row.wachtwoord}</StyledTableCell>
              <StyledTableCell >
                {
                  row.isAdmin?(<><EditIcon sx={{pointer: 'cursor'}}/><DeleteForeverIcon sx={{pointer: 'cursor'}} onClick={()=>{
                    deleteMedewerker(row.medewerkerID);
                  }}/></>):(<Typography>Je hebt geen rechten om iets aan te passen</Typography>)
                }

              </StyledTableCell>
            </StyledTableRow>
          ))
      )
  });
  },[])

  function deleteMedewerker(id){
    axios.delete('http://localhost:11738/Medewerker/'+id).then(()=>{
    console.log("deleted: "+id);
  }).catch((error)=>{
    console.log(error);
  })}

  return (
    <>
    <Navbar/>
    <TableContainer component={Paper} sx={{maxWidth: 1000, margin: "100px auto"}} >
      <Table>
        <TableHead>
          <TableRow>
            <StyledTableCell>Naam</StyledTableCell>
            <StyledTableCell>Wachtwoord</StyledTableCell>
            <StyledTableCell>Acties</StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {datafield}
        </TableBody>
      </Table>
    </TableContainer>
    </>
  )
}