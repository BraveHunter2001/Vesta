export const dateCut = (date) =>
{
    const indexCut = date.indexOf('T');
    if (indexCut === -1)
        return date;
    return date.substring(0,indexCut);
}