export function getCookie(name: string): string | null {
  const cookie = document.cookie
    .split('; ')
    .find((row) => row.startsWith(name));
  // console.log(cookie);
  return !cookie || cookie.indexOf('=') === -1
    ? null
    : cookie.substr(cookie.indexOf('=') + 1);
}

export function setCookie(name: string, value: string, expires?: Date): void {
  if (!expires) {
    const date = new Date();
    expires = new Date(date.getFullYear() + 5, date.getMonth(), date.getDate());
  }
  document.cookie = `${name}=${value}; expires=${expires.toUTCString()}; path=/`;
}
