create view vInventoryReceipt
as
    select rtrim(a.stt_rec)+'_'+ltrim(a.so_ct)+b.stt_rec0  as Id,
        a.ngay_ct as [Date],
        rtrim(b.ma_vt) as ItemId,
        rtrim(c.ten_vt) as ItemName,
        c.dvt as UnitId,
        d.ten_dvt as UnitName,
        b.so_luong as Quantity
    from phlsn as a
        left join ctlsn as b on a.stt_rec = b.stt_rec
        left join dmvt c on b.ma_vt = c.ma_vt
        left join dmdvt d on c.dvt = d.dvt
        
