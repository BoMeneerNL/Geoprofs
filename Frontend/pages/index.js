import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import axios from "axios";
import { Typography } from "@mui/material";
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

export default function Home(props) {
  const [datafield, setDatafield] = useState([]);
  const router = useRouter();
  let datacollector = [];
  useEffect(() => {
    if (props.auth < 2) {
      router.push("/verlof");
    } else {
      axios
        .get("http://localhost:11738/Medewerker")
        .then((response) => {
          datacollector = response.data;
          setDatafield(
            datacollector.map((row, key) => (
              <StyledTableRow key={key}>
                <StyledTableCell component="th" scope="row">
                  {row.naam}
                </StyledTableCell>
                <StyledTableCell>
                  {props.auth["medewerkerType"] > 1 ? (
                    <>
                      <EditIcon sx={{ pointer: "cursor" }} />
                      <DeleteForeverIcon
                        sx={{ pointer: "cursor" }}
                        onClick={() => {
                          deleteMedewerker(row.medewerkerID, key);
                        }}
                      />
                    </>
                  ) : (
                    <Typography>
                      Je hebt geen rechten om iets aan te passen
                    </Typography>
                  )}
                </StyledTableCell>
              </StyledTableRow>
            ))
          );
        })
        .catch(() => {});
    }
  }, []);

  function deleteMedewerker(id, key) {
    axios
      .delete("http://localhost:11738/Medewerker/" + id)
      .then(() => {
        datacollector.splice(key, 1);
        setDatafield(
          datacollector.map((row, key) => (
            <StyledTableRow key={key}>
              <StyledTableCell component="th" scope="row">
                {row.naam}
              </StyledTableCell>
              <StyledTableCell>
                {row.isAdmin ? (
                  <>
                    <EditIcon sx={{ pointer: "cursor" }} />
                    <DeleteForeverIcon
                      sx={{ pointer: "cursor" }}
                      onClick={() => {
                        deleteMedewerker(row.medewerkerID, key);
                      }}
                    />
                  </>
                ) : (
                  <Typography>
                    Je hebt geen rechten om iets aan te passen
                  </Typography>
                )}
              </StyledTableCell>
            </StyledTableRow>
          ))
        );
      })
      .catch((error) => {});
  }

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
              <StyledTableCell>Acties</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>{datafield}</TableBody>
        </Table>
      </TableContainer>
    </>
  );
}
