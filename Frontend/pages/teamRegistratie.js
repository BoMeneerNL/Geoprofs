import React, { useRef, useState, useEffect } from "react";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { useRouter } from "next/router";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Modal,
} from "@mui/material";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";

const theme = createTheme();
const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};
import axios from "axios";
export default function Register() {
  const [open, setOpen] = useState(false);
  const [modalDOM, setModalDOM] = useState(<></>);
  const [teams, setTeams] = useState([]);
  const router = useRouter();
  const inputName = useRef();
  const handleSubmit = (event) => {
    event.preventDefault();

    console.log("hi");
  };
  useEffect(() => {
    axios
      .get("http://localhost:11738/Teams")
      .then((response) => {
        console.log(response.data);
        setTeams(response.data);
      })
      .catch(() => {});
  }, []);
  return (
    <>
      <ThemeProvider theme={theme}>
        <Container component="main" maxWidth="xs">
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Team name</TableCell>
                <TableCell>Acties</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {teams.map((team, idx) => (
                <TableRow
                  key={team.idx}
                  sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {team.naam}
                  </TableCell>
                  <TableCell align="right">
                    <DeleteForeverIcon
                      onClick={() => {
                        axios
                          .delete(`http://localhost:11738/Teams/${team.teamID}`)
                          .then((response) => {
                            window.location.reload();
                          })
                          .catch(() => {});
                      }}
                    />
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </Container>
        <Modal
          open={open}
          onClose={() => {
            setOpen(false);
            setModalDOM(<></>);
          }}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
        >
          <Box sx={style}>{modalDOM}</Box>
        </Modal>
      </ThemeProvider>
    </>
  );
}
