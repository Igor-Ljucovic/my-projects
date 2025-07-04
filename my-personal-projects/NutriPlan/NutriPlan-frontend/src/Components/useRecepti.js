import { useState, useEffect } from 'react';
import axios from 'axios';

const usePreferencije = () => {
   
    const [recepti, setRecepti] = useState([]);
    
    useEffect(() => {
        axios.get("api/recepti")
        .then((response) => {
            setRecepti(response.data.data);
        })
        .catch((error) => {
            console.error("Error fetching recipes:", error);
        });
    }, []);

    const handleDeleteRecept = (id) => {
        const authToken = window.sessionStorage.getItem("auth_token");

        axios.delete(`/api/obroci/recepti/${id}`, {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${authToken}`,
            },
        })
        .then(() => {
            setRecepti(prevState => prevState.filter(recept => recept.id !== id));
            alert("Obroci za recept su uspešno obrisani.");
        })
        .catch(error => {
            console.error("Greška pri brisanju recepta:", error);
            alert("Došlo je do greške pri brisanju obroka za recept.");
        });

        axios.delete(`/api/recepti/${id}`, {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${authToken}`,
            },
        })
        .then(() => {
            setRecepti(prevState => prevState.filter(recept => recept.id !== id));
            alert("Recept je uspešno obrisan.");
        })
        .catch(error => {
            console.error("Greška pri brisanju recepta:", error);
            alert("Došlo je do greške pri brisanju recepta.");
        });
    };

    return {
     recepti,
     handleDeleteRecept
    };
};

export default usePreferencije;
