import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import axios from "axios";
import Navbar from "../components/navbar";
import { useState, useEffect } from "react";
import { useRouter } from "next/router";

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
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));
export default function Verlof() {
  const router = useRouter();
  const [datafield, setDatafield] = useState([]);
  useEffect(() => {
    axios.get("http://localhost:11738/Verlof").then((response) => {
      console.log(response.data);
      setDatafield(
        response.data.map((row, key) => {
          const van = new Date(row.van * 1000).toLocaleDateString();
          const tot = new Date(row.tot * 1000).toLocaleDateString();

          return (
            <StyledTableRow key={key}>
              <StyledTableCell component="th" scope="row">
                {row.naam}
              </StyledTableCell>
              <StyledTableCell>{van}</StyledTableCell>
              <StyledTableCell>{tot}</StyledTableCell>
              <StyledTableCell>{row.isAdmin ? "Yes" : "No"}</StyledTableCell>
            </StyledTableRow>
          );
        })
      );
      console.log(datafield);
    });
  }, []);
  return (
    <>
      <Navbar />
      <TableContainer
        component={Paper}
        sx={{ maxWidth: 1000, margin: "100px auto" }}
      >
        <Table sx={{ minWidth: 350 }}>
          <TableHead>
            <TableRow>
              <StyledTableCell>Naam</StyledTableCell>
              <StyledTableCell>Verlof van</StyledTableCell>
              <StyledTableCell>Verlof tot</StyledTableCell>
              <StyledTableCell>Acties</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>{datafield}</TableBody>
        </Table>
      </TableContainer>
    </>
  );
}
