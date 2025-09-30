function onlyDigits(s) {
  return (s || '').replace(/\D+/g, '');
}

function formatHHMM(s) {
  const d = onlyDigits(s).slice(0, 4);
  if (d.length <= 2) return d;
  return d.slice(0, 2) + ':' + d.slice(2);
}

function clampHHMM(hhmm) {
  if (!hhmm || !/^\d{1,2}:\d{1,2}$/.test(hhmm)) return hhmm;
  let [h, m] = hhmm.split(':');
  let H = Math.min(23, Math.max(0, parseInt(h || '0', 10)));
  let M = Math.min(59, Math.max(0, parseInt(m || '0', 10)));
  return `${String(H).padStart(2, '0')}:${String(M).padStart(2, '0')}`;
}

// parsira HH:MM u broj minuta, vrati null ako nije validan format prosledjen
function parseTimeToMins(hhmm) {
  const m = /^([01]\d|2[0-3]):([0-5]\d)$/.exec((hhmm ?? '').toString().trim());
  return m ? Number(m[1]) * 60 + Number(m[2]) : NaN;
}

export { onlyDigits, formatHHMM, clampHHMM, parseTimeToMins };