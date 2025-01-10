export const checkPermission = (permission) => {
    const permissions = JSON.parse(localStorage.getItem('permissions')) || [];
    return permissions.includes(permission);
  };
  