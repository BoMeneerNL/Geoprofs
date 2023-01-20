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

const MedewerkerVerlof = ({ row, medewerkerType, medewerkerID }) => {
  const van = new Date(row.van * 1000).toLocaleDateString();
  const tot = new Date(row.tot * 1000).toLocaleDateString();

  if (medewerkerID === row.medewerkerID) {
    return (
      <>
        <StyledTableCell component="th" scope="row">
          {row.naam}
        </StyledTableCell>
        <StyledTableCell>{row.teamNaam}</StyledTableCell>
        <StyledTableCell>{van}</StyledTableCell>
        <StyledTableCell>{tot}</StyledTableCell>
        <StyledTableCell>{row.redenVerzoek}</StyledTableCell>
        <StyledTableCell>
          {row.status === 1
            ? "Nog niet beoordeeld"
            : row.status === 2
            ? "Goedgekeurd"
            : row.status === 3
            ? "Afgewezen"
            : "An error occured"}
        </StyledTableCell>
        <StyledTableCell>
          {medewerkerType >= 1 && row.status === 1 ? (
            <>
              <Button
                onClick={() => {
                  changeStatus(row.verlofID, 2);
                }}
              >
                Goedkeuren
              </Button>
              <Button
                onClick={() => {
                  changeStatus(row.verlofID, 3);
                }}
              >
                Afkeuren
              </Button>
            </>
          ) : row.status > 1 ? (
            "Geen acties mogelijk"
          ) : (
            "Geen toegang"
          )}
        </StyledTableCell>
      </>
    );
  }
};

export default MedewerkerVerlof;
