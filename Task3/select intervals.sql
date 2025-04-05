WITH interals AS (
  SELECT id, dt AS sd, LEAD(dt) OVER (PARTITION BY id ORDER BY dt) AS ed
  FROM dates)

SELECT * 
FROM interals
WHERE ed is not null