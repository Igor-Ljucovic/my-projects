function parseLatLng(s) {
  if (!s || typeof s !== 'string') return null;
  const parts = s.split(',').map(t => t.trim());
  if (parts.length !== 2) return null;
  const lat = Number(parts[0]);
  const lng = Number(parts[1]);
  if (!Number.isFinite(lat) || !Number.isFinite(lng)) return null;
  return { lat, lng };
}

export { parseLatLng };