/**
 * Checks if the user is logged in by verifying the presence of a token in localStorage.
 * @returns {boolean} - Returns true if a token exists, false otherwise.
 */
export const isLoggedIn = () => {
    const token = localStorage.getItem('token');
    return !!token;
  };
  