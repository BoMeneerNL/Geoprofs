import {useRouter} from 'next/router';
import {useEffect} from 'react';
import Cookies from "js-cookie";
import { Typography } from '@mui/material';

export default function Logout() {
  const router = useRouter();
  useEffect(() => {
    if (typeof window !== "undefined") {
      Cookies.remove("authtoken");
      window.location.href = "/login";
    }
  }, [router, typeof window]);
  return <Typography>Logging out...</Typography>;
}