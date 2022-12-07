import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import Button from "@mui/material/Button";
import axios from "axios";
import { useEffect, useState } from "react";
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

function changeStatus(verlofId, newStatus) {
  axios.post(`http://localhost:11738/changestatus/${verlofId}/${newStatus}`).then((response) => {
    console.log(response);
  });
  window.location.reload();
}

export default function Verlof(props) {
  const router = useRouter();
  const [datafield, setDatafield] = useState([]);
  const medewerkerId = props.auth['medewerkerID'];
  useEffect(() => {
    axios.get("http://localhost:11738/Verlof").then((response) => {
      setDatafield(
        response.data.map((row, key) => {
          console.log(row)
          if (row['medewerkerID'] === medewerkerId || props.auth['medewerkerType'] >= 1) {
            const van = new Date(row.van * 1000).toLocaleDateString();
            const tot = new Date(row.tot * 1000).toLocaleDateString();
            return (
              <StyledTableRow key={key}>
                <StyledTableCell component="th" scope="row">
                  {row.naam}
                </StyledTableCell>
                <StyledTableCell>{van}</StyledTableCell>
                <StyledTableCell>{tot}</StyledTableCell>
                <StyledTableCell>
                  {row.status === 1
                    ? "nog niet beoordeeld"
                    : row.status === 2
                    ? "Goedgekeurd"
                    : row.status === 3
                    ? "Afgewezen"
                    : "An error occured"}
                </StyledTableCell>
                <StyledTableCell>
                  {props.auth['medewerkerType'] >= 1 ? <><Button onClick={() => {changeStatus(row.verlofID, 2)}}>Goedkeuren</Button><Button onClick={() => {changeStatus(row.verlofID, 3)}}>Afkeuren</Button></> : "No access"}
                </StyledTableCell>
              </StyledTableRow>
            );
          }
        })
      );
    });
  }, [props,medewerkerId]);
  return (
    <>
      <TableContainer
        component={Paper}
        sx={{ maxWidth: "75%", margin: "100px auto" }}
      >
        <Table>
          <TableHead>
            <TableRow>
              <StyledTableCell>Naam</StyledTableCell>
              <StyledTableCell>Verlof van</StyledTableCell>
              <StyledTableCell>Verlof tot</StyledTableCell>
              <StyledTableCell>Status</StyledTableCell>
              <StyledTableCell>Acties</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>{datafield}</TableBody>
        </Table>
      </TableContainer>
    </>
  );
}
