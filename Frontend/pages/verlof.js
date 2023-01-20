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
import MedewerkerVerlof from "../components/MedewerkerVerlof";
import TeamleiderVerlof from "../components/TeamleiderVerlof";
import DirectieVerlof from "../components/DirectieVerlof";

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

const StyledTableRowTeam = styled(TableRow)(({ theme }) => ({
    backgroundColor: "#888888",
    
}));

function changeStatus(verlofId, newStatus) {
  axios
    .post(`http://localhost:11738/changestatus/${verlofId}/${newStatus}`)
    .then((response) => {
      console.log(response);
    })
    .catch(() => {});
  // window.location.reload();
}

export default function Verlof(props) {
  const router = useRouter();
  const [datafield, setDatafield] = useState([]);
  const medewerkerId = props.auth["medewerkerID"];
  const medewerkerType = props.auth["medewerkerType"];
  const teamId = props.auth["teamID"];
  useEffect(() => {
    axios
      .get("http://localhost:11738/Verlof")
      .then((response) => {
        let sortedVerlof = response.data.sort((a, b) => {
          let teamNaamA = a.teamNaam.toLowerCase(),
            teamNaamB = b.teamNaam.toLowerCase();

          if (teamNaamA < teamNaamB) //sort string ascending
            return -1;
          if (teamNaamA > teamNaamB) return 1;
          return 0; //default return value (no sorting)
        });
        console.log(sortedVerlof);

        let previousTeamNaam = "";

        setDatafield(
          sortedVerlof.map((row, key) => {
            console.log(row);

            let currentTeamNaam = row.teamNaam;
            if (key !== 0) {
              previousTeamNaam = sortedVerlof[key - 1].teamNaam;
            }

            console.log(previousTeamNaam);

            
            

            if (medewerkerType === 0) {
              {
                console.log("medewerkerType is 0");
              }
              return (
                <StyledTableRow key={key}>
                  <MedewerkerVerlof
                    row={row}
                    medewerkerType={medewerkerType}
                    medewerkerID={medewerkerId}
                  />
                </StyledTableRow>
              );
            } else if (medewerkerType === 1) {
              {
                console.log("medewerkerType is 1");
              }
              return (
                <StyledTableRow key={key}>
                  <TeamleiderVerlof
                    row={row}
                    medewerkerType={medewerkerType}
                    teamId={teamId}
                  />
                </StyledTableRow>
              );
            } else if (medewerkerType === 2) {
              {
                console.log("medewerkerType is 2");
              }
              return (
                <>
                {currentTeamNaam != previousTeamNaam? <StyledTableRowTeam><TableCell sx={{color: "#fff", fontWeight: "bold", fontSize: 16}} colSpan={7}>{currentTeamNaam}</TableCell></StyledTableRowTeam> : null}
                <StyledTableRow key={key}>
                  <DirectieVerlof row={row} medewerkerType={medewerkerType} />
                </StyledTableRow>
                </>
              );
            }
          })
        );
      })
      .catch(() => {});
  }, [props, medewerkerId]);
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
              <StyledTableCell>Team</StyledTableCell>
              <StyledTableCell>Verlof van</StyledTableCell>
              <StyledTableCell>Verlof tot</StyledTableCell>
              <StyledTableCell>Reden</StyledTableCell>
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
