import Paper from "@mui/material/Paper";
import { useRouter } from "next/router";
import Navbar from '../components/navbar';
import { useEffect } from "react";
import TextField from "@mui/material/TextField";
export default function Verlof() {
  const router = useRouter();
    return(
        <>
        <Navbar/>
        <TextField label={""} />
        <TextField label={""} />
        <TextField label={""} />
      </>
    );
  }